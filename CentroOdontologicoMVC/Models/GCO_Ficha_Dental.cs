using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Ficha_Dental
    {
        public string idFichaDental { get; set; }
        public int nroHistoria { get; set; }
        public string diagnosticoFD { get; set; }
        public string observacionFD { get; set; }
        public string notaAvanceFD { get; set; }
        public Nullable<System.DateTime> fechaRegFD { get; set; }
        public Nullable<System.DateTime> fechaModFD { get; set; }
        public string idEstado { get; set; }
        public virtual GCO_Estado GCO_Estado { get; set; }
        public virtual HistoriaClinica HistoriaClinica { get; set; }
        public virtual ICollection<GCO_Plan_De_Tratamiento> GCO_Plan_De_Tratamiento { get; set; }
    }
}