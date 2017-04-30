using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_Solicitud_De_Insumos_DetalleModel
    {
        public System.Guid idSolInsumDet { get; set; }
        public Nullable<System.Guid> idSolicitudInsumos { get; set; }
        public Nullable<System.Guid> idArticulo { get; set; }
        public Nullable<int> cantidadInsumo { get; set; }
        public Nullable<System.DateTime> fechaRegSID { get; set; }
        public virtual GCO_ArticuloModel GCO_Articulo { get; set; }
        public virtual GCO_Solicitud_De_InsumosModel GCO_Solicitud_De_Insumos { get; set; }
    }
}