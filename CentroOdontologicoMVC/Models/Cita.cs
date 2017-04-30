using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class Cita
    {
        [DisplayName("Número de Cita")]
        public string nroCita { get; set; }

        [DisplayName("Id de Paciente")]
        public Nullable<int> idPaciente { get; set; }

        [DisplayName("Id Profesional")]
        public int nroIdentificProf { get; set; }

        [DisplayName("Id Especialidad")]
        public string idEspecialidad { get; set; }

        [DisplayName("Fecha Cita")]
        public Nullable<System.DateTime> fechaCita { get; set; }

        [DisplayName("Hora Cita")]
        public Nullable<System.DateTime> horaCita { get; set; }

        [DisplayName("Observación")]
        public string observacion { get; set; }

        [DisplayName("Fecha de registro")]
        public System.DateTime fechaRegCita { get; set; }

        [DisplayName("Fecha de modificación")]
        public Nullable<System.DateTime> fechaModCita { get; set; }

        [DisplayName("Id Consultorio")]
        public string idConsultorio { get; set; }

        [DisplayName("Consultorio")]
        public virtual GCO_Consultorio GCO_Consultorio { get; set; }

        [DisplayName("Especialidad")]
        public virtual GCO_Especialidad GCO_Especialidad { get; set; }

        [DisplayName("Paciente")]
        public virtual Paciente Paciente { get; set; }

        [DisplayName("Profesional")]
        public virtual Profesional Profesional { get; set; }
    }
}