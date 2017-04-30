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

namespace GCO.WebApi.Controllers
{
    public class GCO_ConsultorioController : ApiController
    {
        private RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();

        // GET: api/GCO_Consultorio
        public IQueryable<GCO_Consultorio> GetGCO_Consultorio()
        {
            return db.GCO_Consultorio;
        }

        // GET: api/GCO_Consultorio/5
        [ResponseType(typeof(GCO_Consultorio))]
        public async Task<IHttpActionResult> GetGCO_Consultorio(string id)
        {
            GCO_Consultorio gCO_Consultorio = await db.GCO_Consultorio.FindAsync(id);
            if (gCO_Consultorio == null)
            {
                return NotFound();
            }

            return Ok(gCO_Consultorio);
        }

        // PUT: api/GCO_Consultorio/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGCO_Consultorio(string id, GCO_Consultorio gCO_Consultorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gCO_Consultorio.idConsultorio)
            {
                return BadRequest();
            }

            db.Entry(gCO_Consultorio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GCO_ConsultorioExists(id))
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

        // POST: api/GCO_Consultorio
        [ResponseType(typeof(GCO_Consultorio))]
        public async Task<IHttpActionResult> PostGCO_Consultorio(GCO_Consultorio gCO_Consultorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GCO_Consultorio.Add(gCO_Consultorio);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GCO_ConsultorioExists(gCO_Consultorio.idConsultorio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gCO_Consultorio.idConsultorio }, gCO_Consultorio);
        }

        // DELETE: api/GCO_Consultorio/5
        [ResponseType(typeof(GCO_Consultorio))]
        public async Task<IHttpActionResult> DeleteGCO_Consultorio(string id)
        {
            GCO_Consultorio gCO_Consultorio = await db.GCO_Consultorio.FindAsync(id);
            if (gCO_Consultorio == null)
            {
                return NotFound();
            }

            db.GCO_Consultorio.Remove(gCO_Consultorio);
            await db.SaveChangesAsync();

            return Ok(gCO_Consultorio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GCO_ConsultorioExists(string id)
        {
            return db.GCO_Consultorio.Count(e => e.idConsultorio == id) > 0;
        }
    }
}