using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_Tipo_AtencionModel
    {
        public System.Guid idTipoAtencion { get; set; }
        public string descTipoAtencion { get; set; }
        public string estadoTipoAtencion { get; set; }
        public Nullable<System.DateTime> fechaRegTA { get; set; }
        public Nullable<System.DateTime> fechaModTA { get; set; }
        public Nullable<decimal> precioTipoAtencion { get; set; }
        //public virtual ICollection<GCO_Plan_De_Tratamiento_DetalleModel> GCO_Plan_De_Tratamiento_Detalle { get; set; }

        /*

        public GCO_Tipo_Atencion()
        {
            this.GCO_Plan_De_Tratamiento_Detalle = new HashSet<GCO_Plan_De_Tratamiento_Detalle>();
        }

        public System.Guid idTipoAtencion { get; set; }
        public string descTipoAtencion { get; set; }
        public string estadoTipoAtencion { get; set; }
        public Nullable<System.DateTime> fechaRegTA { get; set; }
        public Nullable<System.DateTime> fechaModTA { get; set; }
        public Nullable<decimal> precioTipoAtencion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GCO_Plan_De_Tratamiento_Detalle> GCO_Plan_De_Tratamiento_Detalle { get; set; }
        */
    }
}