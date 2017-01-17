using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SevenCurls.Models;

namespace SevenCurls.Controllers
{
    public class StaffController : Controller
    {
        private ScheduleModelContext db = new ScheduleModelContext();

        // GET: Staff
        public ActionResult Index()
        {
            var staffList = db.StaffList.Include(s => s.Salon);
            return View(staffList.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.StaffList.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            ViewBag.SalonID = new SelectList(db.Salons, "SalonID", "Name");
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffID,SalonID,Fname,Sname,Bio,Availability")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.StaffList.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SalonID = new SelectList(db.Salons, "SalonID", "Name", staff.SalonID);
            return View(staff);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.StaffList.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalonID = new SelectList(db.Salons, "SalonID", "Name", staff.SalonID);
            return View(staff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffID,SalonID,Fname,Sname,Bio,Availability")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SalonID = new SelectList(db.Salons, "SalonID", "Name", staff.SalonID);
            return View(staff);
        }

        // GET: Staff/Search
        public ActionResult Search()
        {
            return View();
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.StaffList.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff staff = db.StaffList.Find(id);
            db.StaffList.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
