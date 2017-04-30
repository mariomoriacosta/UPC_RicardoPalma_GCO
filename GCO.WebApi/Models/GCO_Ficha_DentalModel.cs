using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class GCO_Ficha_DentalModel
    {
        public System.Guid idFichaDental { get; set; }
        public Nullable<System.Guid> idHistoriaClinica { get; set; }
        public string diagnosticoFD { get; set; }
        public string observacionFD { get; set; }
        public string notaAvanceFD { get; set; }
        public Nullable<System.DateTime> fechaRegFD { get; set; }
        public Nullable<System.DateTime> fechaModFD { get; set; }
        public Nullable<System.Guid> idEstado { get; set; }
        public virtual GCO_EstadoModel GCO_Estado { get; set; }
        public virtual GCO_HistoriaClinicaModel GCO_HistoriaClinica { get; set; }
        public virtual ICollection<GCO_Plan_De_TratamientoModel> GCO_Plan_De_Tratamiento { get; set; }
    }
}