using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_ArticuloModel
    {
        public System.Guid idArticulo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string unidadMedida { get; set; }
        public string TipoArticulo { get; set; }
        public Nullable<decimal> costosxUM { get; set; }
        public Nullable<System.DateTime> fechaRegArticulo { get; set; }
        public Nullable<System.DateTime> fechaModArticulo { get; set; }
        public virtual ICollection<GCO_Solicitud_De_Insumos_DetalleModel> GCO_Solicitud_De_Insumos_Detalle { get; set; }
    }
}