using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_Orden_De_Pago_DetalleModel
    {
        public System.Guid idOrdenDePagoDetalle { get; set; }
        public Nullable<System.Guid> idOrdenDePago { get; set; }
        public Nullable<System.Guid> idPlanTratamientoDetalle { get; set; }
        public Nullable<System.Guid> idEstado { get; set; }
        public Nullable<System.DateTime> fechaRegOA { get; set; }
        public Nullable<System.DateTime> fechaModOA { get; set; }
        public Nullable<decimal> PrecioCobrado { get; set; }
        public virtual GCO_EstadoModel GCO_Estado { get; set; }
        public virtual GCO_Orden_De_PagoModel GCO_Orden_De_Pago { get; set; }
        public virtual GCO_Plan_De_Tratamiento_DetalleModel GCO_Plan_De_Tratamiento_Detalle { get; set; }
    }
}