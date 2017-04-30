using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_Solicitud_De_InsumosModel
    {
        public System.Guid idSolicitudInsumos { get; set; }
        public Nullable<System.Guid> idEstado { get; set; }
        public string observacionSI { get; set; }
        public Nullable<System.DateTime> fechaRegSI { get; set; }
        public Nullable<int> nroIdentificProf { get; set; }
        public virtual GCO_EstadoModel GCO_Estado { get; set; }
        public virtual ICollection<GCO_Solicitud_De_Insumos_DetalleModel> GCO_Solicitud_De_Insumos_Detalle { get; set; }
        public virtual ProfesionalModel Profesional { get; set; }
    }
}