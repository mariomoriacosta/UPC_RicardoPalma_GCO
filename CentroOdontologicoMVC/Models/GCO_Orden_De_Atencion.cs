using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Orden_De_Atencion
    {
        public string idOrdenAtencion { get; set; }
        public string idPlanTratamiento { get; set; }
        public string idTipoAtencion { get; set; }
        public string idEstado { get; set; }
        public Nullable<System.DateTime> fechaRegOA { get; set; }
        public Nullable<System.DateTime> fechaModOA { get; set; }
        public virtual GCO_Estado GCO_Estado { get; set; }
        public string nroOrdenPago { get; set; }
        public string numOrdenAtencion { get; set; }

        public virtual ICollection<GCO_Orden_De_Pago> GCO_Orden_De_Pago { get; set; }
        public virtual GCO_Plan_De_Tratamiento GCO_Plan_De_Tratamiento { get; set; }
        public virtual GCO_Tipo_Atencion GCO_Tipo_Atencion { get; set; }

    }
}