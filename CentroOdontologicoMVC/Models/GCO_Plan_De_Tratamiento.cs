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
        public System.Guid idPlanTratamiento { get; set; }
        [DisplayName("Id de Ficha Dental")]
        public Nullable<System.Guid> idFichaDental { get; set; }
        [DisplayName("Descripción de Plan de Tratamiento")]
        public string descPlanTratamiento { get; set; }
        [DisplayName("Fecha de registro")]
        public Nullable<System.DateTime> fechaRegPT { get; set; }
        [DisplayName("Fecha de modificación")]
        public Nullable<System.DateTime> fechaModPT { get; set; }
        [DisplayName("Estado")]
        public Nullable<System.Guid> idEstado { get; set; }
    }
}