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
    
    public partial class GCO_Consultorio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GCO_Consultorio()
        {
            this.GCO_Cita = new HashSet<GCO_Cita>();
        }
    
        public System.Guid idConsultorio { get; set; }
        public string descConsultorio { get; set; }
        public Nullable<bool> estadoConsultorio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GCO_Cita> GCO_Cita { get; set; }
    }
}
