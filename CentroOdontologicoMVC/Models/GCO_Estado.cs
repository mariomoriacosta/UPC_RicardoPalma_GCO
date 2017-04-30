using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Estado
    {
        public System.Guid idEstado { get; set; }
        public string descEstado { get; set; }
        public string paramGrupo { get; set; }
        public Nullable<bool> estadoActivo { get; set; }
    }
}