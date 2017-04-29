using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Especialidad
    {
        public string idEspecialidad { get; set; }
        public string descEspecialidad { get; set; }
        public Nullable<System.DateTime> fechaRegEspec { get; set; }
        public Nullable<System.DateTime> fechaModEspec { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual ICollection<Profesional> Profesional { get; set; }
    }
}