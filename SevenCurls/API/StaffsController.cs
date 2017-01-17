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
    public class StaffsController : ApiController
    {
        private ScheduleModelContext db = new ScheduleModelContext();

        // GET: api/Staffs
        public IQueryable<StaffDTO> GetStaffList()
        {
            var staffList = from s in db.StaffList
                            select new StaffDTO()
                            {
                                StaffID = s.StaffID,
                                FName = s.Fname,
                                SName = s.Sname,
                                Bio = s.Bio 
                            };
            return staffList;
        }

        // GET: api/Staffs/5
        [ResponseType(typeof(StaffDTO))]
        public async Task<IHttpActionResult> GetStaff(int id)
        {
            Staff s = await db.StaffList.FindAsync(id);
            if (s == null)
            {
                return NotFound();
            }

            StaffDTO staff = new StaffDTO
            {
                StaffID = s.StaffID,
                FName = s.Fname,
                SName = s.Sname,
                Bio = s.Bio
            };

            return Ok(staff);
        }

        // PUT: api/Staffs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStaff(int id, Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staff.StaffID)
            {
                return BadRequest();
            }

            db.Entry(staff).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

        // POST: api/Staffs
        [ResponseType(typeof(Staff))]
        public async Task<IHttpActionResult> PostStaff(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StaffList.Add(staff);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = staff.StaffID }, staff);
        }

        // DELETE: api/Staffs/5
        [ResponseType(typeof(Staff))]
        public async Task<IHttpActionResult> DeleteStaff(int id)
        {
            Staff staff = await db.StaffList.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            db.StaffList.Remove(staff);
            await db.SaveChangesAsync();

            return Ok(staff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StaffExists(int id)
        {
            return db.StaffList.Count(e => e.StaffID == id) > 0;
        }
    }
}