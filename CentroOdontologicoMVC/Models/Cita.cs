using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class Cita
    {
        [JsonProperty("nroCita")]
        public string nroCita { get; set; }

        [JsonProperty("idPaciente")]
        public Nullable<int> idPaciente { get; set; }

        [JsonProperty("nroIdentificProf")]
        public int nroIdentificProf { get; set; }

        [JsonProperty("idEspecialidad")]
        public string idEspecialidad { get; set; }

        [JsonProperty("fechaCita")]
        public Nullable<System.DateTime> fechaCita { get; set; }

        [JsonProperty("horaCita")]
        public Nullable<System.DateTime> horaCita { get; set; }

        [JsonProperty("observacion")]
        public string observacion { get; set; }

        [JsonProperty("fechaRegCita")]
        public System.DateTime fechaRegCita { get; set; }

        [JsonProperty("fechaModCita")]
        public Nullable<System.DateTime> fechaModCita { get; set; }

        [JsonProperty("idConsultorio")]
        public string idConsultorio { get; set; }

        [JsonProperty("GCO_Consultorio")]
        public virtual GCO_Consultorio GCO_Consultorio { get; set; }

        [JsonProperty("GCO_Especialidad")]
        public virtual GCO_Especialidad GCO_Especialidad { get; set; }

        [JsonProperty("Paciente")]
        public virtual Paciente Paciente { get; set; }

        [JsonProperty("Profesional")]
        public virtual Profesional Profesional { get; set; }
    }
}