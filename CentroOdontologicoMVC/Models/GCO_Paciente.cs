using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Paciente
    {
        [DisplayName("Id de Paciente")]
        public System.Guid idPaciente { get; set; }
        [DisplayName("Tipo de documento")]
        public string TipoDocIdentidad { get; set; }
        [DisplayName("Número de documento")]
        public string NumDocIdentidad { get; set; }
        [DisplayName("Nombres")]
        public string nombresPaciente { get; set; }
        [DisplayName("Apellido Paterno")]
        public string apePatPaciente { get; set; }
        [DisplayName("Apellido Materno")]
        public string apeMatPaciente { get; set; }
        [DisplayName("Fecha de nacimiento")]
        public Nullable<System.DateTime> fechaNacPaciente { get; set; }
        [DisplayName("País")]
        public string PaisNacPaciente { get; set; }
        [DisplayName("Sexo")]
        public string sexo { get; set; }
        [DisplayName("Teléfono")]
        public string telefono { get; set; }
        [DisplayName("Dirección")]
        public string direccion { get; set; }
        [DisplayName("Distrito")]
        public string distrito { get; set; }
        [DisplayName("Provincia")]
        public string provincia { get; set; }
        [DisplayName("Departamento")]
        public string departamento { get; set; }

        public string fullname 
        {
            get
            {
                return nombresPaciente + " " + apePatPaciente + " " + apeMatPaciente;
            }
        }

    //public virtual ICollection<GCO_Cita> GCO_Cita { get; set; }
    //public virtual ICollection<GCO_HistoriaClinica> GCO_HistoriaClinica { get; set; }

}
}