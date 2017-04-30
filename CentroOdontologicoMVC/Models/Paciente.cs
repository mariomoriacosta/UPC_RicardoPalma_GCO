using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class Paciente
    {
        [DisplayName("Id de Paciente")]
        public int idPaciente { get; set; }
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
        public System.DateTime fechaNacPaciente { get; set; }
        [DisplayName("País")]
        public byte[] PaisNacPaciente { get; set; }
        [DisplayName("Edad")]
        public string edad { get; set; }
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
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual ICollection<HistoriaClinica> HistoriaClinica { get; set; }
    }
}