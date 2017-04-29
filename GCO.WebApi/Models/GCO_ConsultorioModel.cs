using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_ConsultorioModel
    {
        public string idConsultorio { get; set; }
        public string descConsultorio { get; set; }
        public bool estadoConsultorio { get; set; }
        public virtual ICollection<CitaModel> Cita { get; set; }
    }
}