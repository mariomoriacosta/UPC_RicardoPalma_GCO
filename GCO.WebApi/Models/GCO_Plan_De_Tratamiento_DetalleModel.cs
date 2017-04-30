using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_Plan_De_Tratamiento_DetalleModel
    {
        public System.Guid idPlanTratamientoDetalle { get; set; }
        public Nullable<System.Guid> idPlanTratamiento { get; set; }
        public Nullable<System.Guid> idTipoAtencion { get; set; }
        public Nullable<System.DateTime> fechaRegOA { get; set; }
        public Nullable<System.DateTime> fechaModOA { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<GCO_Orden_De_Pago_DetalleModel> GCO_Orden_De_Pago_Detalle { get; set; }
        public virtual GCO_Plan_De_TratamientoModel GCO_Plan_De_Tratamiento { get; set; }
        public virtual GCO_Tipo_AtencionModel GCO_Tipo_Atencion { get; set; }
    }
}