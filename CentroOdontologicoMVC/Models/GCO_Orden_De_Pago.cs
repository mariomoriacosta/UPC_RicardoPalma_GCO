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
        [DisplayName("Número de Orden de Pago")]
        public string nroOrdenPago { get; set; }
        [DisplayName("Precio total")]
        public Nullable<decimal> precioTotOP { get; set; }
        [DisplayName("Descuento")]
        public Nullable<decimal> descuentoOP { get; set; }
        [DisplayName("Fecha de registro")]
        public Nullable<System.DateTime> fechaRegOP { get; set; }
        [DisplayName("Fecha de modificación")]
        public Nullable<System.DateTime> fechaModOP { get; set; }
        [DisplayName("Estado")]
        public string idEstado { get; set; }
    }
}