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
    [RoutePrefix("api/cita")]
    public class CitaController : ApiController
    {
        [Route("")]
        public List<GCO_CitaModel> GetAll()
        {
            try
            {
                var items = from b in LNCita.ListarTodos()
                            select new GCO_CitaModel()
                            {
                                idCita = b.idCita,
                                idPaciente = b.idPaciente,
                                nroIdentificProf = b.nroIdentificProf,
                                idEspecialidad = b.idEspecialidad,
                                fechaCita = b.fechaCita,
                                observacion = b.observacion,
                                fechaRegCita = b.fechaRegCita,
                                fechaModCita = b.fechaModCita,
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

        [Route("{numdoc}/{tipodoc}")]
        public List<GCO_CitaModel> GetForId(string numdoc,string tipodoc)
        {
            try
            {
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<GCO_Paciente, GCO_PacienteModel>();
                    cfg.CreateMap<GCO_Especialidad, GCO_EspecialidadModel>();
                    cfg.CreateMap<GCO_Consultorio, GCO_ConsultorioModel>();
                });

                var items = from b in LNCita.ListarTodos() where b.GCO_Paciente.NumDocIdentidad == numdoc && b.GCO_Paciente.TipoDocIdentidad == tipodoc
                            select new GCO_CitaModel()
                            {
                                idCita = b.idCita,
                                idPaciente = b.idPaciente,
                                nroIdentificProf = b.nroIdentificProf,
                                idEspecialidad = b.idEspecialidad,
                                fechaCita = b.fechaCita,
                                observacion = b.observacion,
                                fechaRegCita = b.fechaRegCita,
                                fechaModCita = b.fechaModCita,
                                idConsultorio = b.idConsultorio,
                                GCO_Paciente = Mapper.Map<GCO_PacienteModel>(b.GCO_Paciente),
                                GCO_Especialidad = Mapper.Map<GCO_EspecialidadModel>(b.GCO_Especialidad),
                                GCO_Consultorio = Mapper.Map<GCO_ConsultorioModel>(b.GCO_Consultorio)
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
