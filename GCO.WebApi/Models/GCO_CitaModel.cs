using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_CitaModel
    {
        public System.Guid idCita { get; set; }
        public Nullable<System.Guid> idPaciente { get; set; }
        public Nullable<int> nroIdentificProf { get; set; }
        public Nullable<System.Guid> idEspecialidad { get; set; }
        public Nullable<System.DateTime> fechaCita { get; set; }
        public string observacion { get; set; }
        public Nullable<System.DateTime> fechaRegCita { get; set; }
        public Nullable<System.DateTime> fechaModCita { get; set; }
        public Nullable<System.Guid> idConsultorio { get; set; }

        public virtual GCO_ConsultorioModel GCO_Consultorio { get; set; }
        public virtual GCO_EspecialidadModel GCO_Especialidad { get; set; }
        public virtual GCO_PacienteModel GCO_Paciente { get; set; }
        public virtual ProfesionalModel Profesional { get; set; }

    }
}