using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_Plan_De_TratamientoModel
    {
        public System.Guid idPlanTratamiento { get; set; }
        public Nullable<System.Guid> idFichaDental { get; set; }
        public string descPlanTratamiento { get; set; }
        public Nullable<System.DateTime> fechaRegPT { get; set; }
        public Nullable<System.DateTime> fechaModPT { get; set; }
        public Nullable<System.Guid> idEstado { get; set; }
        public virtual GCO_EstadoModel GCO_Estado { get; set; }
        public virtual GCO_Ficha_DentalModel GCO_Ficha_Dental { get; set; }
        public virtual ICollection<GCO_Plan_De_Tratamiento_DetalleModel> GCO_Plan_De_Tratamiento_Detalle { get; set; }
    }
}