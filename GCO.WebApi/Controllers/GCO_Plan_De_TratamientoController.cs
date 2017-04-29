using AutoMapper;
using GCO.Datos;
using GCO.Negocio;
using GCO.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GCO.WebApi.Controllers
{
    [RoutePrefix("api/planDeTratamiento")]
    public class GCO_Plan_De_TratamientoController : ApiController
    {
        [Route("")]
        public List<GCO_Plan_De_TratamientoModel> GetAll()
        {
            try
            {
                //Mapper.Initialize(cfg => {
                //    cfg.CreateMap<ICollection<GCO_Orden_De_Atencion>, ICollection<GCO_Orden_De_AtencionModel>>();
                //});

                var items = from b in LNPlanDeTratamiento.ListarTodos()
                            select new GCO_Plan_De_TratamientoModel()
                            {
                                idPlanTratamiento = b.idPlanTratamiento,
                                idFichaDental = b.idFichaDental,
                                descPlanTratamiento = b.descPlanTratamiento,
                                fechaRegPT = b.fechaRegPT,
                                fechaModPT = b.fechaModPT,
                                idEstado = b.idEstado//,
                                //GCO_Orden_De_Atencion = Mapper.Map<ICollection<GCO_Orden_De_AtencionModel>>(b.GCO_Orden_De_Atencion)
                            };
                return items.ToList();
            }
            catch (System.Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "There was an error processing the request"
                };
                throw new HttpResponseException(resp);
            }
        }

        [Route("{id}")]
        public List<GCO_Plan_De_TratamientoModel> GetForIdPaciente(int id)
        {
            try
            {
                var items = from b in LNPlanDeTratamiento.ListarTodos()
                            where b.GCO_Ficha_Dental.HistoriaClinica.idPaciente == id
                            select new GCO_Plan_De_TratamientoModel()
                            {
                                idPlanTratamiento = b.idPlanTratamiento,
                                idFichaDental = b.idFichaDental,
                                descPlanTratamiento = b.descPlanTratamiento,
                                fechaRegPT = b.fechaRegPT,
                                fechaModPT = b.fechaModPT,
                                idEstado = b.idEstado//,
                                //ICollection <GCO_Orden_De_AtencionModel> GCO_Orden_De_Atencion = b.GCO_Orden_De_Atencion
                            };

                //hacer un select de todas las ordenes de atención de los planes de atención del paciente (lista de arriba)
                //y agregarlos al campo correspondiente

                List<GCO_Plan_De_TratamientoModel> nuevaLista = new List<GCO_Plan_De_TratamientoModel>();

                foreach (var item in items)
                {
                    var items2 = from b in LNOrdenDeAtencion.ListarTodos()
                                 where b.idPlanTratamiento == item.idPlanTratamiento
                                 select new GCO_Orden_De_AtencionModel()
                                 {
                                     idOrdenAtencion = b.idOrdenAtencion,
                                     idPlanTratamiento = b.idPlanTratamiento,
                                     idTipoAtencion = b.idTipoAtencion,
                                     idEstado = b.idEstado,
                                     fechaRegOA = b.fechaRegOA,
                                     fechaModOA = b.fechaModOA,
                                     nroOrdenPago = b.nroOrdenPago,
                                     numOrdenAtencion = b.numOrdenAtencion
                                 };

                    item.GCO_Orden_De_Atencion = items2.ToList();
                    nuevaLista.Add(item);
                }

                return nuevaLista.ToList();
            }
            catch (System.Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "There was an error processing the request"
                };
                throw new HttpResponseException(resp);
            }
        }

        //[Route("{id}")]
        //public IHttpActionResult GetItem(int id)
        //{
        //    var b = LNCita.Obtener(id);
        //    if (b == null)
        //    {
        //        var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
        //        {
        //            Content = new StringContent(string.Format("No item with ID = {0}", id)),
        //            ReasonPhrase = "Items ID Not Found"
        //        };
        //        throw new HttpResponseException(resp);
        //    }
        //    else
        //    {
        //        var newItem = new CitaModel()
        //        {
        //            nroCita = b.nroCita,
        //            idPaciente = b.idPaciente,
        //            nroIdentificProf = b.nroIdentificProf,
        //            idEspecialidad = b.idEspecialidad,
        //            fechaCita = b.fechaCita,
        //            horaCita = b.horaCita,
        //            observacion = b.observacion,
        //            idConsultorio = b.idConsultorio
        //        };
        //        return Ok(newItem);
        //    }
        //}
    }
}
