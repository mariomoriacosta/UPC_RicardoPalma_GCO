using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Plan_De_Tratamiento
    {
        [DisplayName("Id de Plan de Tratamiento")]
        public string idPlanTratamiento { get; set; }
        [DisplayName("Id de Ficha Dental")]
        public string idFichaDental { get; set; }
        [DisplayName("Descripción Tratamiento")]
        public string descPlanTratamiento { get; set; }
        [DisplayName("Fecha de registro")]
        public Nullable<System.DateTime> fechaRegPT { get; set; }
        [DisplayName("Fecha de modificación")]
        public Nullable<System.DateTime> fechaModPT { get; set; }
        [DisplayName("Estado")]
        public string idEstado { get; set; }
        //public virtual GCO_Estado GCO_Estado { get; set; }
        //public virtual GCO_Ficha_Dental GCO_Ficha_Dental { get; set; }
        public virtual ICollection<GCO_Orden_De_Atencion> GCO_Orden_De_Atencion { get; set; }
        //public virtual GCO_Tipo_Atencion GCO_Tipo_Atencion { get; set; }
    }
}