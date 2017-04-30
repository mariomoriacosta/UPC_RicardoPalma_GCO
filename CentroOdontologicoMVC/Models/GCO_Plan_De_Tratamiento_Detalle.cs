using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Plan_De_Tratamiento_Detalle
    {
        [DisplayName("Id de Plan de Tratamiento Detalle")]
        public System.Guid idPlanTratamientoDetalle { get; set; }
        [DisplayName("Id de Plan de Tratamiento")]
        public Nullable<System.Guid> idPlanTratamiento { get; set; }
        [DisplayName("Id Tipo de Atención")]
        public Nullable<System.Guid> idTipoAtencion { get; set; }
        [DisplayName("Fecha de registro")]
        public Nullable<System.DateTime> fechaRegOA { get; set; }
        [DisplayName("Fecha de modificación")]
        public Nullable<System.DateTime> fechaModOA { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Tipo de atención")]
        public virtual GCO_Tipo_Atencion GCO_Tipo_Atencion { get; set; }

        public string estadoLista { get; set; }

    }
}