using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GCO.Datos;
using GCO.Negocio;
using GCO.WebApi.Models;

namespace GCO.WebApi.Controllers
{
    public class GCO_Orden_De_PagoController2 : ApiController
    {
        private RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();

        // GET: api/GCO_Orden_De_Pago
        public List<GCO_Orden_De_PagoModel> GetGCO_Orden_De_Pago()
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

            //return db.GCO_Orden_De_Pago;
        }

        // GET: api/GCO_Orden_De_Pago/5
        [ResponseType(typeof(GCO_Orden_De_Pago))]
        public async Task<IHttpActionResult> GetGCO_Orden_De_Pago(string id)
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

        // PUT: api/GCO_Orden_De_Pago/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGCO_Orden_De_Pago(string id, GCO_Orden_De_Pago gCO_Orden_De_Pago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gCO_Orden_De_Pago.nroOrdenPago)
            {
                return BadRequest();
            }

            db.Entry(gCO_Orden_De_Pago).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GCO_Orden_De_PagoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GCO_Orden_De_Pago
        [ResponseType(typeof(GCO_Orden_De_PagoModel))]
        public async Task<IHttpActionResult> Create(GCO_Orden_De_PagoModel valor)
        {
            return Ok(valor);
        }

        //////[ResponseType(typeof(string))]
        //////public async Task<IHttpActionResult> PostGCO_Orden_De_Pago(string valor)
        //////{
        //////    return Ok(valor);
        //////}

        // DELETE: api/GCO_Orden_De_Pago/5
        [ResponseType(typeof(GCO_Orden_De_Pago))]
        public async Task<IHttpActionResult> DeleteGCO_Orden_De_Pago(string id)
        {
            GCO_Orden_De_Pago gCO_Orden_De_Pago = await db.GCO_Orden_De_Pago.FindAsync(id);
            if (gCO_Orden_De_Pago == null)
            {
                return NotFound();
            }

            db.GCO_Orden_De_Pago.Remove(gCO_Orden_De_Pago);
            await db.SaveChangesAsync();

            return Ok(gCO_Orden_De_Pago);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GCO_Orden_De_PagoExists(string id)
        {
            return db.GCO_Orden_De_Pago.Count(e => e.nroOrdenPago == id) > 0;
        }
    }
}