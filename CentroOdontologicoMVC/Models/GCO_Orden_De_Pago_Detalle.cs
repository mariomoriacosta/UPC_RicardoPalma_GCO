using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Orden_De_Pago_Detalle
    {
        [DisplayName("Id Orden de pago detalle")]
        public System.Guid idOrdenDePagoDetalle { get; set; }
        [DisplayName("Id orden de pago")]
        public Nullable<System.Guid> idOrdenDePago { get; set; }
        [DisplayName("Id plan de tratamiento")]
        public Nullable<System.Guid> idPlanTratamientoDetalle { get; set; }
        [DisplayName("Id estado")]
        public Nullable<System.Guid> idEstado { get; set; }
        [DisplayName("Fecha de registro")]
        public Nullable<System.DateTime> fechaRegOA { get; set; }
        [DisplayName("Fecha de modificación")]
        public Nullable<System.DateTime> fechaModOA { get; set; }
        [DisplayName("Precio cobrado")]
        public Nullable<decimal> PrecioCobrado { get; set; }

    }
}