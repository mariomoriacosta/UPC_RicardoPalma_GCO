using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Plan_De_Tratamiento
    {
        public string idPlanTratamiento { get; set; }
        public string idFichaDental { get; set; }
        public string descPlanTratamiento { get; set; }
        public Nullable<System.DateTime> fechaRegPT { get; set; }
        public Nullable<System.DateTime> fechaModPT { get; set; }
        public string idEstado { get; set; }
        //public virtual GCO_Estado GCO_Estado { get; set; }
        //public virtual GCO_Ficha_Dental GCO_Ficha_Dental { get; set; }
        public virtual ICollection<GCO_Orden_De_Atencion> GCO_Orden_De_Atencion { get; set; }
        //public virtual GCO_Tipo_Atencion GCO_Tipo_Atencion { get; set; }
    }
}