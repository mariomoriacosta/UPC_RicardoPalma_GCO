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
    [RoutePrefix("api/cita")]
    public class CitaController : ApiController
    {
        [Route("")]
        public List<CitaModel> GetAll()
        {
            try
            {
                var items = from b in LNCita.ListarTodos()
                            select new CitaModel()
                            {
                                nroCita = b.nroCita,
                                idPaciente = b.idPaciente,
                                nroIdentificProf = b.nroIdentificProf,
                                idEspecialidad = b.idEspecialidad,
                                fechaCita = b.fechaCita,
                                horaCita = b.horaCita,
                                observacion = b.observacion,
                                idConsultorio = b.idConsultorio
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
        public List<CitaModel> GetForId(int id)
        {
            try
            {
                var items = from b in LNCita.ListarTodos() where b.idPaciente == id
                            select new CitaModel()
                            {
                                nroCita = b.nroCita,
                                idPaciente = b.idPaciente,
                                nroIdentificProf = b.nroIdentificProf,
                                idEspecialidad = b.idEspecialidad,
                                fechaCita = b.fechaCita,
                                horaCita = b.horaCita,
                                observacion = b.observacion,
                                idConsultorio = b.idConsultorio
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
