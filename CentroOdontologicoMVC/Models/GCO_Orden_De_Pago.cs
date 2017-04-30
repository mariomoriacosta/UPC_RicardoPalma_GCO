using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Orden_De_Pago
    {
        [DisplayName("Id Orden de Pago")]
        public System.Guid idOrdenDePago { get; set; }
        [DisplayName("Precio total")]
        public Nullable<decimal> precioTotOP { get; set; }
        [DisplayName("Descuento")]
        public Nullable<decimal> descuentoOP { get; set; }
        [DisplayName("Fecha de registro")]
        public Nullable<System.DateTime> fechaRegOP { get; set; }
        [DisplayName("Fecha de modificación")]
        public Nullable<System.DateTime> fechaModOP { get; set; }
        [DisplayName("Id Estado")]
        public Nullable<System.Guid> idEstado { get; set; }
        [DisplayName("Estado")]
        public virtual GCO_Estado GCO_Estado { get; set; }

    }
}