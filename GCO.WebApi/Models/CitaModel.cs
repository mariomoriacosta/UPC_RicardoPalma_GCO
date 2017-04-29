using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class CitaModel
    {
        public string nroCita { get; set; }
        public Nullable<int> idPaciente { get; set; }
        public int nroIdentificProf { get; set; }
        public string idEspecialidad { get; set; }
        public Nullable<System.DateTime> fechaCita { get; set; }
        public Nullable<System.DateTime> horaCita { get; set; }
        public string observacion { get; set; }
        public System.DateTime fechaRegCita { get; set; }
        public Nullable<System.DateTime> fechaModCita { get; set; }
        public string idConsultorio { get; set; }
        public virtual GCO_ConsultorioModel GCO_Consultorio { get; set; }
        public virtual GCO_EspecialidadModel GCO_Especialidad { get; set; }
        public virtual PacienteModel Paciente { get; set; }
        public virtual ProfesionalModel Profesional { get; set; }
    }
}