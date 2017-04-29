using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Solicitud_De_Insumos
    {
        public string idSolicitudInsumos { get; set; }
        public string idEstado { get; set; }
        public string observacionSI { get; set; }
        public Nullable<System.DateTime> fechaRegSI { get; set; }
        public int nroIdentificProf { get; set; }
        public virtual GCO_Estado GCO_Estado { get; set; }
        public virtual ICollection<GCO_Solicitud_De_Insumos_Detalle> GCO_Solicitud_De_Insumos_Detalle { get; set; }
        public virtual Profesional Profesional { get; set; }
    }
}