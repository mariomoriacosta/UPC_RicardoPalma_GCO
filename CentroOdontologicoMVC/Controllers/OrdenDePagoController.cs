using CentroOdontologicoMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace CentroOdontologicoMVC.Controllers
{
    public class OrdenDePagoController : Controller
    {
        //holi



        // GET: Item
        public async Task<ActionResult> Index()
        {
            List<GCO_Orden_De_Pago> listado = new List<GCO_Orden_De_Pago>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("OrdenDePago");

                if (Res.IsSuccessStatusCode)
                {  
                    var responseData = Res.Content.ReadAsStringAsync().Result;
                    listado = JsonConvert.DeserializeObject<List<GCO_Orden_De_Pago>>(responseData);
                }

                return View(listado);
            }
        }

        public ActionResult GenerarOrdenDePago()
        {
            int estadoProceso = 0;
            string tipoDOcumento = "";
            string numDocumento = "";
            ICollection<GCO_Cita> Citas = null;
            GCO_Cita CitaSeleccionada = null;
            string IdCitaSeleccionada = "";
            GCO_Paciente Paciente = new GCO_Paciente();
            Paciente.fechaNacPaciente = DateTime.Parse("1900/01/01");
            ICollection<GCO_Plan_De_Tratamiento_Detalle> planDeTratamientoDetalle = null;
            GCO_Plan_De_Tratamiento PlanVacio = new GCO_Plan_De_Tratamiento();
            GCO_Plan_De_Tratamiento_Detalle planDeTratamientoDetalleVacio = new GCO_Plan_De_Tratamiento_Detalle();

            GCO_Tipo_Atencion tipo_atencion = new GCO_Tipo_Atencion();
            GCO_Estado estado = new GCO_Estado();
            planDeTratamientoDetalleVacio.GCO_Tipo_Atencion = tipo_atencion;
            //--planDeTratamientoDetalleVacio.GCO_Estado = estado;

            GCO_Orden_De_Pago ordenDePago = new GCO_Orden_De_Pago();

            //List<System.Web.Mvc.SelectListItem> listaTipoDocumento = new List<System.Web.Mvc.SelectListItem>(){
            //   new SelectListItem { Value = "1", Text = "DNI" },
            //   new SelectListItem { Value = "2", Text = "Carnet Extr." },
            //   new SelectListItem { Value = "2", Text = "Pasaporte" }
            //};
            
            GenerarOrdenDePagoModel generarOrdenDePagoModel = new GenerarOrdenDePagoModel();
            generarOrdenDePagoModel.estadoProceso = estadoProceso;
            generarOrdenDePagoModel.tipoDOcumento = tipoDOcumento;
            generarOrdenDePagoModel.numDocumento = numDocumento;
            generarOrdenDePagoModel.Citas = Citas;
            generarOrdenDePagoModel.CitaSeleccionada = CitaSeleccionada;
            generarOrdenDePagoModel.IdCitaSeleccionada = IdCitaSeleccionada;
            generarOrdenDePagoModel.Paciente = Paciente;
            generarOrdenDePagoModel.PlanDeTratamientoDetalle = planDeTratamientoDetalle;
            generarOrdenDePagoModel.PlanVacio = PlanVacio;
            generarOrdenDePagoModel.PlanDeTratamientoDetalleVacio = planDeTratamientoDetalleVacio;
            generarOrdenDePagoModel.OrdenDePago = ordenDePago;
            generarOrdenDePagoModel.ItemsSeleccionados = "";
            generarOrdenDePagoModel.PrecioAcumuladoTotal = 0.00;
            //generarOrdenDePagoModel.listaTipoDocumento = listaTipoDocumento;
            @ViewBag.Message = "";
            return View(generarOrdenDePagoModel);
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> GenerarOrdenDePago(GenerarOrdenDePagoModel generarOrdenDePagoModel)
        {
            if (generarOrdenDePagoModel.estadoProceso == 0) //ha presionado el boton buscar cita
            {                
                List<GCO_Cita> listado = new List<GCO_Cita>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("cita/" + generarOrdenDePagoModel.numDocumento+"/"+ generarOrdenDePagoModel.tipoDOcumento);

                    if (Res.IsSuccessStatusCode)
                    {
                        var responseData = Res.Content.ReadAsStringAsync().Result;
                        listado = JsonConvert.DeserializeObject<List<GCO_Cita>>(responseData);
                    }

                    if (listado.Count > 0)
                    {   //si encuentra citas, aumenta estado del proceso y retorna
                        generarOrdenDePagoModel.estadoProceso = 1;

                        generarOrdenDePagoModel.Citas = listado;
                        return View(generarOrdenDePagoModel);
                    }else
                    {
                        generarOrdenDePagoModel.estadoProceso = 0;
                        @ViewBag.Message = "No hay citas";
                        return View(generarOrdenDePagoModel);
                    }
                }              
            }
            else if (generarOrdenDePagoModel.estadoProceso == 1)
            {

                @ViewBag.Message = "";

                generarOrdenDePagoModel.estadoProceso = 2;

                GCO_Paciente paciente = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("paciente/" + generarOrdenDePagoModel.numDocumento + "/" + generarOrdenDePagoModel.tipoDOcumento);

                    if (Res.IsSuccessStatusCode)
                    {
                        var responseData = Res.Content.ReadAsStringAsync().Result;
                        paciente = JsonConvert.DeserializeObject<GCO_Paciente>(responseData);
                    }

                    if (paciente != null)
                    {   //si encuentra citas, aumenta estado del proceso y retorna
                        generarOrdenDePagoModel.estadoProceso = 3;
                        generarOrdenDePagoModel.Paciente = paciente;
                        return View(generarOrdenDePagoModel);
                    }
                    else
                    {
                        generarOrdenDePagoModel.estadoProceso = 0;
                        @ViewBag.Message = "No se encontró un paciente con el id: "+ generarOrdenDePagoModel.IdCitaSeleccionada;
                        return View(generarOrdenDePagoModel);
                    }
                }

            }
            else if (generarOrdenDePagoModel.estadoProceso == 2)
            {
                @ViewBag.Message = "";
            }
            else if (generarOrdenDePagoModel.estadoProceso == 3)
            {
                generarOrdenDePagoModel.estadoProceso = 4;

                //guardar datos del paciente

                UpdatePacienteAsync(generarOrdenDePagoModel.Paciente);
                
                //mandar el plan de tratamiento

                List<GCO_Plan_De_Tratamiento_Detalle> listado = new List<GCO_Plan_De_Tratamiento_Detalle>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("planDeTratamientoDetalle/" + generarOrdenDePagoModel.Paciente.idPaciente);

                    if (Res.IsSuccessStatusCode)
                    {
                        var responseData = Res.Content.ReadAsStringAsync().Result;
                        listado = JsonConvert.DeserializeObject<List<GCO_Plan_De_Tratamiento_Detalle>>(responseData);
                    }

                    if (listado != null)
                    {   //si encuentra citas, aumenta estado del proceso y retorna

                        foreach (var item in listado)
                        {
                            item.estadoLista = "Pendiente";
                        }

                        generarOrdenDePagoModel.estadoProceso = 5;
                        generarOrdenDePagoModel.PlanDeTratamientoDetalle = listado;
                        
                        return View(generarOrdenDePagoModel);
                    }
                    else
                    {
                        generarOrdenDePagoModel.estadoProceso = 4;
                        @ViewBag.Message = "No se encontró un paciente con el id: " + generarOrdenDePagoModel.IdCitaSeleccionada;
                    }
                }
                @ViewBag.Message = "";
                return View(generarOrdenDePagoModel);
            }
            else if (generarOrdenDePagoModel.estadoProceso == 4)
            {
                @ViewBag.Message = "";
            }
            else if (generarOrdenDePagoModel.estadoProceso == 5)
            {
                List<GCO_Plan_De_Tratamiento_Detalle> listado = new List<GCO_Plan_De_Tratamiento_Detalle>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("planDeTratamientoDetalle/" + generarOrdenDePagoModel.Paciente.idPaciente);

                    if (Res.IsSuccessStatusCode)
                    {
                        var responseData = Res.Content.ReadAsStringAsync().Result;
                        listado = JsonConvert.DeserializeObject<List<GCO_Plan_De_Tratamiento_Detalle>>(responseData);
                    }

                    if (listado != null)
                    {   //si encuentra citas, aumenta estado del proceso y retorna
                        generarOrdenDePagoModel.PlanDeTratamientoDetalle = listado;

                        double precioAcumulado = 0.00;

                        var tmp = (generarOrdenDePagoModel.ItemsSeleccionados+"").Split(',');
                        
                        foreach (var item in listado)
                        {
                            for (int i = 0; i < tmp.Length; i++)
                            {
                                try
                                {
                                    if (item.idPlanTratamientoDetalle == Guid.Parse(tmp[i].Replace("*", "").Replace("+", "")))
                                    {
                                        precioAcumulado += double.Parse(item.GCO_Tipo_Atencion.precioTipoAtencion.ToString());
                                        item.estadoLista = "Seleccionado";
                                    }
                                }
                                catch (Exception)
                                {
                                }                                
                             }                     
                        }
                        generarOrdenDePagoModel.PrecioAcumuladoTotal = precioAcumulado;
                        @ViewBag.PrecioAcumulado = precioAcumulado;
                        
                        return View(generarOrdenDePagoModel);
                    }
                }

                @ViewBag.Message = "";

                return View(generarOrdenDePagoModel);
            }
            else if (generarOrdenDePagoModel.estadoProceso == 6)
            {
                List<GCO_Plan_De_Tratamiento_Detalle> listado = new List<GCO_Plan_De_Tratamiento_Detalle>();
                double precioAcumulado = 0.00;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("planDeTratamientoDetalle/" + generarOrdenDePagoModel.Paciente.idPaciente);

                    if (Res.IsSuccessStatusCode)
                    {
                        var responseData = Res.Content.ReadAsStringAsync().Result;
                        listado = JsonConvert.DeserializeObject<List<GCO_Plan_De_Tratamiento_Detalle>>(responseData);
                    }

                    if (listado != null)
                    {   //si encuentra citas, aumenta estado del proceso y retorna
                        generarOrdenDePagoModel.PlanDeTratamientoDetalle = listado;

                        var tmp = (generarOrdenDePagoModel.ItemsSeleccionados + "").Split(',');

                        foreach (var item in listado)
                        {
                            for (int i = 0; i < tmp.Length; i++)
                            {
                                try
                                {
                                    if (item.idPlanTratamientoDetalle == Guid.Parse(tmp[i].Replace("*", "").Replace("+", "")))
                                    {
                                        precioAcumulado += double.Parse(item.GCO_Tipo_Atencion.precioTipoAtencion.ToString());
                                        item.estadoLista = "Seleccionado";
                                    }
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                }

                GCO_Orden_De_Pago p = new GCO_Orden_De_Pago();
                p.idOrdenDePago = Guid.NewGuid();
                p.precioTotOP = decimal.Parse(precioAcumulado+"");
                p.descuentoOP = 0;
                p.fechaRegOP = DateTime.Now;
                p.fechaModOP = DateTime.Now;
                p.idEstado = Guid.Parse("8190C843-00BA-487E-AFA9-6D793FFE7AEC");

                CreateAsync(p);

                return RedirectToAction("Index","OrdenDePago");
            }

            return RedirectToAction("Index", "OrdenDePago");
        }


        static async Task<Uri> CreateAsync(GCO_Orden_De_Pago o)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync("ordenDePago", o);
                var r =  response;
                return null;
            }
        }

        static async Task<Uri> UpdatePacienteAsync(GCO_Paciente o)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PutAsJsonAsync("paciente", o);
                return null;
            }
        }

    }
}
