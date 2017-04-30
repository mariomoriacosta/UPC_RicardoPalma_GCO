using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_Orden_De_PagoModel
    {
        public System.Guid idOrdenDePago { get; set; }
        public Nullable<decimal> precioTotOP { get; set; }
        public Nullable<decimal> descuentoOP { get; set; }
        public Nullable<System.DateTime> fechaRegOP { get; set; }
        public Nullable<System.DateTime> fechaModOP { get; set; }
        public Nullable<System.Guid> idEstado { get; set; }
        public virtual GCO_EstadoModel GCO_Estado { get; set; }
    }
}