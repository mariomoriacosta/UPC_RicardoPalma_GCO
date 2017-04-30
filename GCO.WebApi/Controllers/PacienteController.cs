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
    [RoutePrefix("api/paciente")]
    public class PacienteController : ApiController
    {
        [Route("")]
        public List<GCO_PacienteModel> GetAll()
        {
            try
            {
                var items = from b in LNPaciente.ListarTodos()
                            select new GCO_PacienteModel()
                            {
                                idPaciente = b.idPaciente,
                                TipoDocIdentidad = b.TipoDocIdentidad,
                                NumDocIdentidad = b.NumDocIdentidad,
                                nombresPaciente = b.nombresPaciente,
                                apePatPaciente = b.apePatPaciente,
                                apeMatPaciente = b.apeMatPaciente,
                                fechaNacPaciente = b.fechaNacPaciente,
                                PaisNacPaciente = b.PaisNacPaciente,
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

        [Route("{numdoc}/{tipodoc}")]
        public IHttpActionResult GetForId(string numdoc, string tipodoc)
        {
            var b = LNPaciente.Obtener(numdoc, tipodoc);
            if (b == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No item with ID = {0}", numdoc)),
                    ReasonPhrase = "Items ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
            else
            {
                var newItem = new GCO_PacienteModel()
                {
                    idPaciente = b.idPaciente,
                    TipoDocIdentidad = b.TipoDocIdentidad,
                    NumDocIdentidad = b.NumDocIdentidad,
                    nombresPaciente = b.nombresPaciente,
                    apePatPaciente = b.apePatPaciente,
                    apeMatPaciente = b.apeMatPaciente,
                    fechaNacPaciente = b.fechaNacPaciente,
                    PaisNacPaciente = b.PaisNacPaciente,
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

        [Route("")]
        [HttpPut]
        public IHttpActionResult Update([FromBody] GCO_PacienteModel p)
        {
            if (p == null)
            {
                return BadRequest();
            }

            var pa = new GCO_Paciente();
            pa.idPaciente = p.idPaciente;
            pa.TipoDocIdentidad = p.TipoDocIdentidad;
            pa.NumDocIdentidad = p.NumDocIdentidad;
            pa.nombresPaciente = p.nombresPaciente;
            pa.apePatPaciente = p.apePatPaciente;
            pa.apeMatPaciente = p.apeMatPaciente;
            pa.fechaNacPaciente = p.fechaNacPaciente;
            pa.PaisNacPaciente = p.PaisNacPaciente;
            pa.sexo = p.sexo;
            pa.telefono = p.telefono;
            pa.direccion = p.direccion;
            pa.distrito = p.distrito;
            pa.provincia = p.provincia;
            pa.departamento = p.departamento;

            LNPaciente.update(pa);
            return Ok(p);
        }
    }
}
