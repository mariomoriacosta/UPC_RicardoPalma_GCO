//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GCO.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class GCO_Plan_De_Tratamiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GCO_Plan_De_Tratamiento()
        {
            this.GCO_Orden_De_Atencion = new HashSet<GCO_Orden_De_Atencion>();
        }
    
        public string idPlanTratamiento { get; set; }
        public string idFichaDental { get; set; }
        public string descPlanTratamiento { get; set; }
        public Nullable<System.DateTime> fechaRegPT { get; set; }
        public Nullable<System.DateTime> fechaModPT { get; set; }
        public string idEstado { get; set; }
    
        public virtual GCO_Estado GCO_Estado { get; set; }
        public virtual GCO_Ficha_Dental GCO_Ficha_Dental { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GCO_Orden_De_Atencion> GCO_Orden_De_Atencion { get; set; }
    }
}