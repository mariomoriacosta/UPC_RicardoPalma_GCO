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
    
    public partial class Profesional
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profesional()
        {
            this.GCO_Cita = new HashSet<GCO_Cita>();
            this.GCO_Solicitud_De_Insumos = new HashSet<GCO_Solicitud_De_Insumos>();
        }
    
        public int nroIdentificProf { get; set; }
        public string tipoDocIdentidad { get; set; }
        public string numDocIdentidad { get; set; }
        public System.Guid IdEspecialidad { get; set; }
        public string nombresProf { get; set; }
        public string apePatProf { get; set; }
        public string apeMatProf { get; set; }
        public Nullable<System.DateTime> fechaNacProf { get; set; }
        public string sexo { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string distrito { get; set; }
        public string provincia { get; set; }
        public string departamento { get; set; }
        public string nroColegiatura { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GCO_Cita> GCO_Cita { get; set; }
        public virtual GCO_Especialidad GCO_Especialidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GCO_Solicitud_De_Insumos> GCO_Solicitud_De_Insumos { get; set; }
    }
}
