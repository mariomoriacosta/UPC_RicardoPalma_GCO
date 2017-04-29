using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Solicitud_De_Insumos_Detalle
    {
        public string idSolInsumDet { get; set; }
        public string idSolicitudInsumos { get; set; }
        public int codArticulo { get; set; }
        public Nullable<int> cantidadInsumo { get; set; }
        public Nullable<System.DateTime> fechaRegSID { get; set; }
        public virtual Articulo Articulo { get; set; }
        public virtual GCO_Solicitud_De_Insumos GCO_Solicitud_De_Insumos { get; set; }
    }
}