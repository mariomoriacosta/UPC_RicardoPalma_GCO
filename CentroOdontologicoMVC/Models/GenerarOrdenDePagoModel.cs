using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CentroOdontologicoMVC.Controllers.OrdenDePagoController;

namespace CentroOdontologicoMVC.Models
{
    public class GenerarOrdenDePagoModel
    {
        //estado del proceso de generacion de cita
        public int estadoProceso { get; set; }

        //lista de tipos de documento
        //public List<System.Web.Mvc.SelectListItem> listaTipoDocumento { get; set; }

        //tipo y numero de documento seleccionado
        [DisplayName("Tipo de documento")]
        public string tipoDOcumento { get; set; }

        //tipo y numero de documento seleccionado
        [DisplayName("Número de documento")]
        public string numDocumento { get; set; }

        //lista de citas
        public ICollection<GCO_Cita> Citas { get; set; }

        //cita seleccionada
        public GCO_Cita CitaSeleccionada { get; set; }
        public string IdCitaSeleccionada { get; set; }

        //Paciente (el que será actualizado)
        public GCO_Paciente Paciente { get; set; }

        //lista de tratamientos con sus estados (marcado o no)
        //public GCO_Plan_De_Tratamiento PlanDeTratamiento { get; set; }
        public ICollection<GCO_Plan_De_Tratamiento_Detalle> PlanDeTratamientoDetalle { get; set; }
        public GCO_Plan_De_Tratamiento PlanVacio { get; set; }
        public GCO_Plan_De_Tratamiento_Detalle PlanDeTratamientoDetalleVacio { get; set; }

        //orden de pago a crear
        public GCO_Orden_De_Pago OrdenDePago { get; set; }

        public string ItemsSeleccionados { get; set; }
        public double PrecioAcumuladoTotal { get; set; }

    }
}