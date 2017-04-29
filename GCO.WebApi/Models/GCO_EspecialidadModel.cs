using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_EspecialidadModel
    {
        public string idEspecialidad { get; set; }
        public string descEspecialidad { get; set; }
        public Nullable<System.DateTime> fechaRegEspec { get; set; }
        public Nullable<System.DateTime> fechaModEspec { get; set; }
        public virtual ICollection<CitaModel> Cita { get; set; }
        public virtual ICollection<ProfesionalModel> Profesional { get; set; }
    }
}