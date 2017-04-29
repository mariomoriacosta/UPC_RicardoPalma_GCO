using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Consultorio
    {
        public string idConsultorio { get; set; }
        public string descConsultorio { get; set; }
        public bool estadoConsultorio { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
    }
}