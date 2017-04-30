using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class ProfesionalModel
    {
        public int nroIdentificProf { get; set; }
        public string tipoDocIdentidad { get; set; }
        public string numDocIdentidad { get; set; }
        public System.Guid IdEspecialidad { get; set; }
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
        public virtual ICollection<GCO_CitaModel> GCO_Cita { get; set; }
        public virtual GCO_EspecialidadModel GCO_Especialidad { get; set; }
        public virtual ICollection<GCO_Solicitud_De_InsumosModel> GCO_Solicitud_De_Insumos { get; set; }
    }
}