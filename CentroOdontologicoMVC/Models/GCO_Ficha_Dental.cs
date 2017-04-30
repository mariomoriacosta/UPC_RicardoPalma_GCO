using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Ficha_Dental
    {
        public System.Guid idFichaDental { get; set; }
        public Nullable<System.Guid> idHistoriaClinica { get; set; }
        public string diagnosticoFD { get; set; }
        public string observacionFD { get; set; }
        public string notaAvanceFD { get; set; }
        public Nullable<System.DateTime> fechaRegFD { get; set; }
        public Nullable<System.DateTime> fechaModFD { get; set; }
        public Nullable<System.Guid> idEstado { get; set; }
        public virtual GCO_Estado GCO_Estado { get; set; }
        public virtual GCO_HistoriaClinica GCO_HistoriaClinica { get; set; }
    }
}