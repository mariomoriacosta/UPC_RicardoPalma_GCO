using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_PacienteModel
    {
        public System.Guid idPaciente { get; set; }
        public string TipoDocIdentidad { get; set; }
        public string NumDocIdentidad { get; set; }
        public string nombresPaciente { get; set; }
        public string apePatPaciente { get; set; }
        public string apeMatPaciente { get; set; }
        public Nullable<System.DateTime> fechaNacPaciente { get; set; }
        public string PaisNacPaciente { get; set; }
        public string sexo { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string distrito { get; set; }
        public string provincia { get; set; }
        public string departamento { get; set; }
        //public virtual ICollection<GCO_CitaModel> GCO_Cita { get; set; }
        //public virtual ICollection<GCO_HistoriaClinicaModel> GCO_HistoriaClinica { get; set; }
    }
}