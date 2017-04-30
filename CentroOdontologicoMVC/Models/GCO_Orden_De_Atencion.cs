using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Orden_De_Atencion
    {
        [DisplayName("Id Orden de atención")]
        public string idOrdenAtencion { get; set; }
        [DisplayName("Id Plan de tratamiento")]
        public string idPlanTratamiento { get; set; }
        [DisplayName("Id Tipo de atención")]
        public string idTipoAtencion { get; set; }
        [DisplayName("Estado")]
        public string idEstado { get; set; }
        [DisplayName("Fecha de registro")]
        public Nullable<System.DateTime> fechaRegOA { get; set; }
        [DisplayName("Fecha de modificación")]
        public Nullable<System.DateTime> fechaModOA { get; set; }
        [DisplayName("Estado")]
        public virtual GCO_Estado GCO_Estado { get; set; }
        [DisplayName("Num Orden de Pago")]
        public string nroOrdenPago { get; set; }
        [DisplayName("Num Orden de Atención")]
        public string numOrdenAtencion { get; set; }

        public virtual ICollection<GCO_Orden_De_Pago> GCO_Orden_De_Pago { get; set; }
        public virtual GCO_Plan_De_Tratamiento GCO_Plan_De_Tratamiento { get; set; }
        public virtual GCO_Tipo_Atencion GCO_Tipo_Atencion { get; set; }

    }
}