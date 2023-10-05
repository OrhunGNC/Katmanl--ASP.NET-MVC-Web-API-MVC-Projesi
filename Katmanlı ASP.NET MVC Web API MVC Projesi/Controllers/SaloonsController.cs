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
using Katmanlı_ASP.NET_MVC_Web_API_MVC_Projesi.Models;

namespace Katmanlı_ASP.NET_MVC_Web_API_MVC_Projesi.Controllers
{
    public class SaloonsController : ApiController
    {
        private GymEntities db = new GymEntities();

        // GET: api/Saloons
        public IQueryable<Saloon> GetSaloons()
        {
            return db.Saloons;
        }

        // GET: api/Saloons/5
        [ResponseType(typeof(Saloon))]
        public async Task<IHttpActionResult> GetSaloon(int id)
        {
            Saloon saloon = await db.Saloons.FindAsync(id);
            if (saloon == null)
            {
                return NotFound();
            }

            return Ok(saloon);
        }

        // PUT: api/Saloons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSaloon(int id, Saloon saloon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != saloon.SaloonNo)
            {
                return BadRequest();
            }

            db.Entry(saloon).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaloonExists(id))
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

        // POST: api/Saloons
        [ResponseType(typeof(Saloon))]
        public async Task<IHttpActionResult> PostSaloon(Saloon saloon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Saloons.Add(saloon);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = saloon.SaloonNo }, saloon);
        }

        // DELETE: api/Saloons/5
        [ResponseType(typeof(Saloon))]
        public async Task<IHttpActionResult> DeleteSaloon(int id)
        {
            Saloon saloon = await db.Saloons.FindAsync(id);
            if (saloon == null)
            {
                return NotFound();
            }

            db.Saloons.Remove(saloon);
            await db.SaveChangesAsync();

            return Ok(saloon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaloonExists(int id)
        {
            return db.Saloons.Count(e => e.SaloonNo == id) > 0;
        }
    }
}