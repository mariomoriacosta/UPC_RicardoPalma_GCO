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
    [RoutePrefix("api/ordenDeAtencion")]
    public class CGO_Orden_De_AtencionController : ApiController
    {
        [Route("")]
        public List<GCO_Orden_De_AtencionModel> GetAll()
        {
            try
            {
                var items = from b in LNOrdenDeAtencion.ListarTodos()
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
        public List<GCO_Orden_De_AtencionModel> GetForIdPaciente(int id)
        {
            try
            {
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<GCO_Tipo_Atencion, GCO_Tipo_AtencionModel>();
                });

                var items = from b in LNOrdenDeAtencion.ListarTodos()
                            where b.GCO_Plan_De_Tratamiento.GCO_Ficha_Dental.HistoriaClinica.Paciente.idPaciente == id
                            select new GCO_Orden_De_AtencionModel()
                            {
                                idOrdenAtencion = b.idOrdenAtencion,
                                idPlanTratamiento = b.idPlanTratamiento,
                                idTipoAtencion = b.idTipoAtencion,
                                idEstado = b.GCO_Estado.descEstado,
                                GCO_Tipo_Atencion = Mapper.Map<GCO_Tipo_AtencionModel>(b.GCO_Tipo_Atencion),
                                fechaRegOA = b.fechaRegOA,
                                fechaModOA = b.fechaModOA,
                                nroOrdenPago = b.nroOrdenPago,
                                numOrdenAtencion = b.numOrdenAtencion
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



    }
}
