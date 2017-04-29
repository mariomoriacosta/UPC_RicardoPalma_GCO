using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Estado
    {
        public string idEstado { get; set; }
        public string descEstado { get; set; }
        public string paramGrupo { get; set; }
        public Nullable<bool> estadoActivo { get; set; }
        public virtual ICollection<GCO_Ficha_Dental> GCO_Ficha_Dental { get; set; }
        public virtual ICollection<GCO_Orden_De_Pago> GCO_Orden_De_Pago { get; set; }
        public virtual ICollection<GCO_Orden_De_Atencion> GCO_Orden_De_Atencion { get; set; }
        public virtual ICollection<GCO_Plan_De_Tratamiento> GCO_Plan_De_Tratamiento { get; set; }
        public virtual ICollection<GCO_Solicitud_De_Insumos> GCO_Solicitud_De_Insumos { get; set; }
    }
}