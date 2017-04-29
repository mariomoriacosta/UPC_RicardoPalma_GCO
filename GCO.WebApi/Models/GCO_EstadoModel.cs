using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_EstadoModel
    {
        public string idEstado { get; set; }
        public string descEstado { get; set; }
        public string paramGrupo { get; set; }
        public Nullable<bool> estadoActivo { get; set; }
        public virtual ICollection<GCO_Ficha_DentalModel> GCO_Ficha_Dental { get; set; }
        public virtual ICollection<GCO_Orden_De_PagoModel> GCO_Orden_De_Pago { get; set; }
        public virtual ICollection<GCO_Orden_De_AtencionModel> GCO_Orden_De_Atencion { get; set; }
        public virtual ICollection<GCO_Plan_De_TratamientoModel> GCO_Plan_De_Tratamiento { get; set; }
        public virtual ICollection<GCO_Solicitud_De_InsumosModel> GCO_Solicitud_De_Insumos { get; set; }
    }
}