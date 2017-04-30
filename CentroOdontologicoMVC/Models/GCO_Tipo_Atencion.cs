using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Tipo_Atencion
    {
        public System.Guid idTipoAtencion { get; set; }
        public string descTipoAtencion { get; set; }
        public string estadoTipoAtencion { get; set; }
        public Nullable<System.DateTime> fechaRegTA { get; set; }
        public Nullable<System.DateTime> fechaModTA { get; set; }
        public Nullable<decimal> precioTipoAtencion { get; set; }
    }
}