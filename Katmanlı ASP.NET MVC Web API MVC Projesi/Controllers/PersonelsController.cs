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
    public class PersonelsController : ApiController
    {
        private GymEntities db = new GymEntities();

        // GET: api/Personels
        public IQueryable<Personel> GetPersonels()
        {
            return db.Personels;
        }

        // GET: api/Personels/5
        [ResponseType(typeof(Personel))]
        public async Task<IHttpActionResult> GetPersonel(int id)
        {
            Personel personel = await db.Personels.FindAsync(id);
            if (personel == null)
            {
                return NotFound();
            }

            return Ok(personel);
        }

        // PUT: api/Personels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersonel(int id, Personel personel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personel.PersonelNo)
            {
                return BadRequest();
            }

            db.Entry(personel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonelExists(id))
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

        // POST: api/Personels
        [ResponseType(typeof(Personel))]
        public async Task<IHttpActionResult> PostPersonel(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personels.Add(personel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = personel.PersonelNo }, personel);
        }

        // DELETE: api/Personels/5
        [ResponseType(typeof(Personel))]
        public async Task<IHttpActionResult> DeletePersonel(int id)
        {
            Personel personel = await db.Personels.FindAsync(id);
            if (personel == null)
            {
                return NotFound();
            }

            db.Personels.Remove(personel);
            await db.SaveChangesAsync();

            return Ok(personel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonelExists(int id)
        {
            return db.Personels.Count(e => e.PersonelNo == id) > 0;
        }
    }
}