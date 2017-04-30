using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_ConsultorioModel
    {
        public System.Guid idConsultorio { get; set; }
        public string descConsultorio { get; set; }
        public Nullable<bool> estadoConsultorio { get; set; }
    }
}