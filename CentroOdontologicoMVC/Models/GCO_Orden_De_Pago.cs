using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroOdontologicoMVC.Models
{
    public class GCO_Orden_De_Pago
    {
        [JsonProperty("nroOrdenPago")]
        public string nroOrdenPago { get; set; }
        [JsonProperty("idOrdenAtencion")]
        public string idOrdenAtencion { get; set; }
        [JsonProperty("nroIdentificProf")]
        public int nroIdentificProf { get; set; }
        [JsonProperty("precioTotOP")]
        public decimal? precioTotOP { get; set; }
        [JsonProperty("descuentoOP")]
        public decimal? descuentoOP { get; set; }
        [JsonProperty("fechaRegOP")]
        public DateTime? fechaRegOP { get; set; }
        [JsonProperty("fechaModOP")]
        public DateTime? fechaModOP { get; set; }
        [JsonProperty("idEstado")]
        public string idEstado { get; set; }
    }
}