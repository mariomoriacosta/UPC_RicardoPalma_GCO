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
    
    public partial class GCO_Especialidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GCO_Especialidad()
        {
            this.Cita = new HashSet<Cita>();
            this.Profesional = new HashSet<Profesional>();
        }
    
        public string idEspecialidad { get; set; }
        public string descEspecialidad { get; set; }
        public Nullable<System.DateTime> fechaRegEspec { get; set; }
        public Nullable<System.DateTime> fechaModEspec { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profesional> Profesional { get; set; }
    }
}
