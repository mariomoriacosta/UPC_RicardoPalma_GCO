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
    [RoutePrefix("api/planDeTratamientoDetalle")]
    public class GCO_Plan_De_Tratamiento_DetalleController : ApiController
    {
        [Route("")]
        public List<GCO_Plan_De_Tratamiento_DetalleModel> GetAll()
        {
            try
            {
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<GCO_Tipo_Atencion, GCO_Tipo_AtencionModel>();
                });

                var items = from b in LNPlanDeTratamientoDetalle.ListarTodos()
                            select new GCO_Plan_De_Tratamiento_DetalleModel()
                            {
                                idPlanTratamientoDetalle = b.idPlanTratamientoDetalle,
                                idPlanTratamiento = b.idPlanTratamiento,
                                idTipoAtencion = b.idTipoAtencion,
                                fechaRegOA = b.fechaRegOA,
                                fechaModOA = b.fechaModOA,
                                Descripcion = b.Descripcion,
                                GCO_Tipo_Atencion = Mapper.Map<GCO_Tipo_AtencionModel>(b.GCO_Tipo_Atencion)
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
        public List<GCO_Plan_De_Tratamiento_DetalleModel> GetForIdPaciente(string id)
        {
            try
            {
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<GCO_Tipo_Atencion, GCO_Tipo_AtencionModel>();
                });

                var items = from b in LNPlanDeTratamientoDetalle.ListarTodos()
                            where b.GCO_Plan_De_Tratamiento.GCO_Ficha_Dental.GCO_HistoriaClinica.GCO_Paciente.idPaciente == Guid.Parse(id)
                            select new GCO_Plan_De_Tratamiento_DetalleModel()
                            {
                                idPlanTratamientoDetalle = b.idPlanTratamientoDetalle,
                                idPlanTratamiento = b.idPlanTratamiento,
                                idTipoAtencion = b.idTipoAtencion,
                                fechaRegOA = b.fechaRegOA,
                                fechaModOA = b.fechaModOA,
                                Descripcion = b.Descripcion,
                                GCO_Tipo_Atencion = Mapper.Map<GCO_Tipo_AtencionModel>(b.GCO_Tipo_Atencion)
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
