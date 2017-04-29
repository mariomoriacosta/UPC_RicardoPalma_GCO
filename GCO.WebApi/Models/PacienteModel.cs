using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class PacienteModel
    {
        public int idPaciente { get; set; }
        public string TipoDocIdentidad { get; set; }
        public string NumDocIdentidad { get; set; }
        public string nombresPaciente { get; set; }
        public string apePatPaciente { get; set; }
        public string apeMatPaciente { get; set; }
        public System.DateTime fechaNacPaciente { get; set; }
        public byte[] PaisNacPaciente { get; set; }
        public string edad { get; set; }
        public string sexo { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string distrito { get; set; }
        public string provincia { get; set; }
        public string departamento { get; set; }
        public virtual ICollection<CitaModel> Cita { get; set; }
        public virtual ICollection<HistoriaClinicaModel> HistoriaClinica { get; set; }
    }
}