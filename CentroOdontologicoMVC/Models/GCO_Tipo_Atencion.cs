using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Tipo_Atencion
    {
        public string idTipoAtencion { get; set; }
        public string descTipoAtencion { get; set; }
        public string estadoTipoAtencion { get; set; }
        public Nullable<System.DateTime> fechaRegTA { get; set; }
        public Nullable<System.DateTime> fechaModTA { get; set; }
        public Nullable<decimal> precioTipoAtencion { get; set; }
        public virtual ICollection<GCO_Orden_De_Atencion> GCO_Orden_De_Atencion { get; set; }
        public virtual ICollection<GCO_Plan_De_Tratamiento> GCO_Plan_De_Tratamiento { get; set; }
    }
}