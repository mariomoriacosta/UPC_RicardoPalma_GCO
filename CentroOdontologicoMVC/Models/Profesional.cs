using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class Profesional
    {
        public int nroIdentificProf { get; set; }
        public string tipoDocIdentidad { get; set; }
        public string numDocIdentidad { get; set; }
        public string IdEspecialidad { get; set; }
        public string nombresProf { get; set; }
        public string apePatProf { get; set; }
        public string apeMatProf { get; set; }
        public Nullable<System.DateTime> fechaNacProf { get; set; }
        public string sexo { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string distrito { get; set; }
        public string provincia { get; set; }
        public string departamento { get; set; }
        public string nroColegiatura { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual GCO_Especialidad GCO_Especialidad { get; set; }
        public virtual ICollection<GCO_Orden_De_Pago> GCO_Orden_De_Pago { get; set; }
        public virtual ICollection<GCO_Solicitud_De_Insumos> GCO_Solicitud_De_Insumos { get; set; }
    }
}