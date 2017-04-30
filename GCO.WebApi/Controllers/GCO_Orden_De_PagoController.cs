using GCO.Datos;
using GCO.Negocio;
using GCO.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace GCO.WebApi.Controllers
{
    [RoutePrefix("api/ordenDePago")]
    public class GCO_Orden_De_PagoController : ApiController
    {
        [Route("")]
        public List<GCO_Orden_De_PagoModel> GetAll()
        {
            try
            {
                var items = from b in LNOrdenDePago.ListarTodos()
                            select new GCO_Orden_De_PagoModel()
                            {
                                nroOrdenPago = b.nroOrdenPago,
                                //idOrdenAtencion = b.idOrdenAtencion,
                                //nroIdentificProf = b.nroIdentificProf,
                                precioTotOP = b.precioTotOP,
                                descuentoOP = b.descuentoOP,
                                fechaRegOP = b.fechaRegOP,
                                fechaModOP = b.fechaModOP,
                                idEstado = b.idEstado
                            };
                return items.ToList();
            }
            catch (System.Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "There was an error processing the request"
                };
                throw new HttpResponseException(resp);
            }

        }

        [Route("{id}")]
        public IHttpActionResult GetItem(string id)
        {
            var item = LNOrdenDePago.Obtener(id);
            if (item == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No item with ID = {0}", id)),
                    ReasonPhrase = "Items ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
            else
            {
                var newItem = new GCO_Orden_De_PagoModel()
                {
                    nroOrdenPago = item.nroOrdenPago,
                    //idOrdenAtencion = item.idOrdenAtencion,
                    //nroIdentificProf = item.nroIdentificProf,
                    precioTotOP = item.precioTotOP,
                    descuentoOP = item.descuentoOP,
                    fechaRegOP = item.fechaRegOP,
                    fechaModOP = item.fechaModOP,
                    idEstado = item.idEstado
                };
                return Ok(newItem);
            }
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] GCO_Orden_De_PagoModel b)
        {
            if (b == null)
            {
                return BadRequest();
            }

            var p = new GCO_Orden_De_Pago();
            p.nroOrdenPago = b.nroOrdenPago;
            p.precioTotOP = b.precioTotOP;
            p.descuentoOP = b.descuentoOP;
            p.fechaRegOP = b.fechaRegOP;
            p.fechaModOP = b.fechaModOP;
            p.idEstado = b.idEstado;

            LNOrdenDePago.add(p);
            return Ok(b);
        }

        
    }
}
