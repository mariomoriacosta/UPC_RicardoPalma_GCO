using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_Plan_De_TratamientoModel
    {
        public string idPlanTratamiento { get; set; }
        public string idFichaDental { get; set; }
        public string descPlanTratamiento { get; set; }
        public Nullable<System.DateTime> fechaRegPT { get; set; }
        public Nullable<System.DateTime> fechaModPT { get; set; }
        public string idEstado { get; set; }
        //public virtual GCO_EstadoModel GCO_Estado { get; set; }
        //public virtual GCO_Ficha_DentalModel GCO_Ficha_Dental { get; set; }
        public virtual ICollection<GCO_Orden_De_AtencionModel> GCO_Orden_De_Atencion { get; set; }
        //public virtual GCO_Tipo_AtencionModel GCO_Tipo_Atencion { get; set; }
    }
}