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
using SevenCurls.Models;

namespace SevenCurls.API
{
    public class SalonsController : ApiController
    {
        private ScheduleModelContext db = new ScheduleModelContext();

        // GET: api/Salons
        public IQueryable<SalonDTO> GetSalons()
        {
            var salons = from s in db.Salons
                         select new SalonDTO()
                         {
                             SalonID = s.SalonID,
                             Name = s.Name,
                             Street = s.Street,
                             City = s.City
                         };
            return salons;
        }

        // GET: api/Salons/5
        [ResponseType(typeof(SalonDTO))]
        public async Task<IHttpActionResult> GetSalon(int id)
        {
            Salon s = await db.Salons.FindAsync(id);
            if (s == null)
            {
                return NotFound();
            }

            SalonDTO salon = new SalonDTO
            {
                SalonID = s.SalonID,
                Name = s.Name,
                Street = s.Street,
                City = s.City
            };

            return Ok(salon);
        }

        // PUT: api/Salons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSalon(int id, Salon salon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salon.SalonID)
            {
                return BadRequest();
            }

            db.Entry(salon).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalonExists(id))
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

        // POST: api/Salons
        [ResponseType(typeof(Salon))]
        public async Task<IHttpActionResult> PostSalon(Salon salon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Salons.Add(salon);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = salon.SalonID }, salon);
        }

        // DELETE: api/Salons/5
        [ResponseType(typeof(Salon))]
        public async Task<IHttpActionResult> DeleteSalon(int id)
        {
            Salon salon = await db.Salons.FindAsync(id);
            if (salon == null)
            {
                return NotFound();
            }

            db.Salons.Remove(salon);
            await db.SaveChangesAsync();

            return Ok(salon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalonExists(int id)
        {
            return db.Salons.Count(e => e.SalonID == id) > 0;
        }
    }
}