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
            ICollection<Cita> Citas = null;
            Cita CitaSeleccionada = null;
            string IdCitaSeleccionada = "";
            Paciente Paciente = new Paciente();
            Paciente.fechaNacPaciente = DateTime.Parse("1900/01/01");
            ICollection<GCO_Orden_De_Atencion> OrdenDeAtencion = null;
            GCO_Plan_De_Tratamiento PlanVacio = new GCO_Plan_De_Tratamiento();
            GCO_Orden_De_Atencion OrdenVacio = new GCO_Orden_De_Atencion();

            GCO_Tipo_Atencion tipo_atencion = new GCO_Tipo_Atencion();
            GCO_Estado estado = new GCO_Estado();
            OrdenVacio.GCO_Tipo_Atencion = tipo_atencion;
            OrdenVacio.GCO_Estado = estado;

            GCO_Orden_De_Pago OrdenDePago = new GCO_Orden_De_Pago();

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
            generarOrdenDePagoModel.OrdenDeAtencion = OrdenDeAtencion;
            generarOrdenDePagoModel.PlanVacio = PlanVacio;
            generarOrdenDePagoModel.OrdenVacio = OrdenVacio;
            generarOrdenDePagoModel.OrdenDePago = OrdenDePago;
            generarOrdenDePagoModel.ItemsSeleccionados = "";
            //generarOrdenDePagoModel.listaTipoDocumento = listaTipoDocumento;

            return View(generarOrdenDePagoModel);
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> GenerarOrdenDePago(GenerarOrdenDePagoModel generarOrdenDePagoModel)
        {
            if (generarOrdenDePagoModel.estadoProceso == 0) //ha presionado el boton buscar cita
            {                
                List<Cita> listado = new List<Cita>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("cita/" + generarOrdenDePagoModel.numDocumento);

                    if (Res.IsSuccessStatusCode)
                    {
                        var responseData = Res.Content.ReadAsStringAsync().Result;
                        listado = JsonConvert.DeserializeObject<List<Cita>>(responseData);
                    }

                    if (listado.Count > 0)
                    {   //si encuentra citas, aumenta estado del proceso y retorna
                        generarOrdenDePagoModel.estadoProceso = 1;

                        generarOrdenDePagoModel.Citas = listado;
                        @ViewBag.Message = "Sí hay citas";
                        return View(generarOrdenDePagoModel);
                    }else
                    {
                        generarOrdenDePagoModel.estadoProceso = 0;
                        @ViewBag.Message = "No hay citas";
                    }
                }              
            }
            else if (generarOrdenDePagoModel.estadoProceso == 1)
            {

                @ViewBag.Message = "aca agrego el paciente";


                generarOrdenDePagoModel.estadoProceso = 2;

                Paciente paciente = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("paciente/" + generarOrdenDePagoModel.IdCitaSeleccionada);

                    if (Res.IsSuccessStatusCode)
                    {
                        var responseData = Res.Content.ReadAsStringAsync().Result;
                        paciente = JsonConvert.DeserializeObject<Paciente>(responseData);
                    }

                    if (paciente != null)
                    {   //si encuentra citas, aumenta estado del proceso y retorna
                        generarOrdenDePagoModel.estadoProceso = 3;
                        generarOrdenDePagoModel.Paciente = paciente;
                        return View(generarOrdenDePagoModel);
                    }
                    else
                    {
                        generarOrdenDePagoModel.estadoProceso = 2;
                        @ViewBag.Message = "No se encontró un paciente con el id: "+ generarOrdenDePagoModel.IdCitaSeleccionada;
                    }
                }

                return View(generarOrdenDePagoModel);

            }
            else if (generarOrdenDePagoModel.estadoProceso == 2)
            {

            }
            else if (generarOrdenDePagoModel.estadoProceso == 3)
            {
                generarOrdenDePagoModel.estadoProceso = 4;

                //guardar datos del paciente

                //mandar el plan de tratamiento

                List<GCO_Orden_De_Atencion> listado = new List<GCO_Orden_De_Atencion>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("ordenDeAtencion/" + generarOrdenDePagoModel.Paciente.idPaciente);

                    if (Res.IsSuccessStatusCode)
                    {
                        var responseData = Res.Content.ReadAsStringAsync().Result;
                        listado = JsonConvert.DeserializeObject<List<GCO_Orden_De_Atencion>>(responseData);
                    }

                    if (listado != null)
                    {   //si encuentra citas, aumenta estado del proceso y retorna
                        generarOrdenDePagoModel.estadoProceso = 5;
                        generarOrdenDePagoModel.OrdenDeAtencion = listado;
                        
                        return View(generarOrdenDePagoModel);
                    }
                    else
                    {
                        generarOrdenDePagoModel.estadoProceso = 4;
                        @ViewBag.Message = "No se encontró un paciente con el id: " + generarOrdenDePagoModel.IdCitaSeleccionada;
                    }
                }

                return View(generarOrdenDePagoModel);
            }
            else if (generarOrdenDePagoModel.estadoProceso == 4)
            {

            }
            else if (generarOrdenDePagoModel.estadoProceso == 5)
            {
                List<GCO_Orden_De_Atencion> listado = new List<GCO_Orden_De_Atencion>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("ordenDeAtencion/" + generarOrdenDePagoModel.Paciente.idPaciente);

                    if (Res.IsSuccessStatusCode)
                    {
                        var responseData = Res.Content.ReadAsStringAsync().Result;
                        listado = JsonConvert.DeserializeObject<List<GCO_Orden_De_Atencion>>(responseData);
                    }

                    if (listado != null)
                    {   //si encuentra citas, aumenta estado del proceso y retorna
                        generarOrdenDePagoModel.OrdenDeAtencion = listado;

                        double precioAcumulado = 0.00;

                        var tmp = generarOrdenDePagoModel.ItemsSeleccionados.Split(',');
                        
                        foreach (var item in listado)
                        {
                            for (int i = 0; i < tmp.Length; i++)
                            {
                                if (item.idOrdenAtencion == tmp[i])
                                {
                                    precioAcumulado += double.Parse(item.GCO_Tipo_Atencion.precioTipoAtencion.ToString());
                                    item.idEstado = "Seleccionado";
                                }
                             }                     
                        }

                        @ViewBag.PrecioAcumulado = precioAcumulado;
                        return View(generarOrdenDePagoModel);
                    }
                }

                

                return View(generarOrdenDePagoModel);
            }
            else if (generarOrdenDePagoModel.estadoProceso == 6)
            {
                //Genrar la orden de pago y regresar al index

                GCO_Orden_De_Pago o = new GCO_Orden_De_Pago();
                o.nroOrdenPago = "2";

                //foreach (var item in generarOrdenDePagoModel.OrdenDeAtencion)
                //{
                //    o.idOrdenAtencion = item.idOrdenAtencion;
                //}

                o.nroIdentificProf = 1;
                o.precioTotOP = ViewBag.PrecioAcumulado;
                o.descuentoOP = 0;

                DateTime dt = new DateTime();

                o.fechaRegOP = dt.Date;
                o.fechaModOP = dt.Date;
                o.idEstado = "1";
                
                CreateAsync(o);

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

                HttpResponseMessage response = await client.PostAsJsonAsync("api/GCO_Orden_De_Pago", o);
                return null;
            }
        }


    }
}
