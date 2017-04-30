using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Cita
    {
        [DisplayName("Número de Cita")]
        public System.Guid idCita { get; set; }
        [DisplayName("Paciente")]
        public Nullable<System.Guid> idPaciente { get; set; }
        [DisplayName("Id Profesional")]
        public Nullable<int> nroIdentificProf { get; set; }
        [DisplayName("Especialidad")]
        public Nullable<System.Guid> idEspecialidad { get; set; }
        [DisplayName("Fecha Cita")]
        public Nullable<System.DateTime> fechaCita { get; set; }
        [DisplayName("Observación")]
        public string observacion { get; set; }
        [DisplayName("Fecha de registro")]
        public Nullable<System.DateTime> fechaRegCita { get; set; }
        [DisplayName("Fecha de modificación")]
        public Nullable<System.DateTime> fechaModCita { get; set; }
        [DisplayName("Id Consultorio")]
        public Nullable<System.Guid> idConsultorio { get; set; }

        public virtual GCO_Paciente GCO_Paciente { get; set; }
        public virtual GCO_Consultorio GCO_Consultorio { get; set; }
        public virtual GCO_Especialidad GCO_Especialidad { get; set; }

    }
}