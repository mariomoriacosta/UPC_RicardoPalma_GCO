using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCO.WebApi.Models
{
    public class HistoriaClinicaModel
    {
        public int nroHistoria { get; set; }
        public Nullable<int> idPaciente { get; set; }
        public string grupoSanguineo { get; set; }
        public string observacion { get; set; }
        public Nullable<System.DateTime> fechaCreacion { get; set; }
        public Nullable<System.DateTime> fechaActualizacion { get; set; }
        public virtual ICollection<GCO_Ficha_DentalModel> GCO_Ficha_Dental { get; set; }
        public virtual PacienteModel Paciente { get; set; }
    }
}