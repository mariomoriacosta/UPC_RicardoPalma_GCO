﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_HistoriaClinica
    {
        public System.Guid idHistoriaClinica { get; set; }
        public Nullable<System.Guid> idPaciente { get; set; }
        public string grupoSanguineo { get; set; }
        public string observacion { get; set; }
        public Nullable<System.DateTime> fechaCreacion { get; set; }
        public Nullable<System.DateTime> fechaActualizacion { get; set; }
        public virtual ICollection<GCO_Ficha_Dental> GCO_Ficha_Dental { get; set; }
        public virtual GCO_Paciente GCO_Paciente { get; set; }
    }
}