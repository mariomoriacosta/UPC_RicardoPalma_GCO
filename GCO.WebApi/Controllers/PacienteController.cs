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
    [RoutePrefix("api/paciente")]
    public class PacienteController : ApiController
    {
        [Route("")]
        public List<PacienteModel> GetAll()
        {
            try
            {
                var items = from b in LNPaciente.ListarTodos()
                            select new PacienteModel()
                            {
                                idPaciente = b.idPaciente,
                                TipoDocIdentidad = b.TipoDocIdentidad,
                                NumDocIdentidad = b.NumDocIdentidad,
                                nombresPaciente = b.nombresPaciente,
                                apePatPaciente = b.apePatPaciente,
                                apeMatPaciente = b.apeMatPaciente,
                                fechaNacPaciente = b.fechaNacPaciente,
                                PaisNacPaciente = b.PaisNacPaciente,
                                edad = b.edad,
                                sexo = b.sexo,
                                telefono = b.telefono,
                                direccion = b.direccion,
                                distrito = b.distrito,
                                provincia = b.provincia,
                                departamento = b.departamento
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
        //public List<PacienteModel> GetForId(int id)
        //{
        //    try
        //    {
        //        var items = from b in LNPaciente.ListarTodos()
        //                    where b.idPaciente == id
        //                    select new PacienteModel()
        //                    {
        //                        idPaciente = b.idPaciente,
        //                        TipoDocIdentidad = b.TipoDocIdentidad,
        //                        NumDocIdentidad = b.NumDocIdentidad,
        //                        nombresPaciente = b.nombresPaciente,
        //                        apePatPaciente = b.apePatPaciente,
        //                        apeMatPaciente = b.apeMatPaciente,
        //                        fechaNacPaciente = b.fechaNacPaciente,
        //                        PaisNacPaciente = b.PaisNacPaciente,
        //                        edad = b.edad,
        //                        sexo = b.sexo,
        //                        telefono = b.telefono,
        //                        direccion = b.direccion,
        //                        distrito = b.distrito,
        //                        provincia = b.provincia,
        //                        departamento = b.departamento
        //                    };
        //        return items.ToList();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
        //        {
        //            Content = new StringContent(ex.Message),
        //            ReasonPhrase = "There was an error processing the request"
        //        };
        //        throw new HttpResponseException(resp);
        //    }
        //}

        [Route("{id}")]
        public IHttpActionResult GetItem(int id)
        {
            var b = LNPaciente.Obtener(id);
            if (b == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No item with ID = {0}", id)),
                    ReasonPhrase = "Items ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
            else
            {
                var newItem = new PacienteModel()
                {
                    idPaciente = b.idPaciente,
                    TipoDocIdentidad = b.TipoDocIdentidad,
                    NumDocIdentidad = b.NumDocIdentidad,
                    nombresPaciente = b.nombresPaciente,
                    apePatPaciente = b.apePatPaciente,
                    apeMatPaciente = b.apeMatPaciente,
                    fechaNacPaciente = b.fechaNacPaciente,
                    PaisNacPaciente = b.PaisNacPaciente,
                    edad = b.edad,
                    sexo = b.sexo,
                    telefono = b.telefono,
                    direccion = b.direccion,
                    distrito = b.distrito,
                    provincia = b.provincia,
                    departamento = b.departamento
                };
                return Ok(newItem);
            }
        }
    }
}
