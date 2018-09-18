using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using work_01.Models;

namespace work_01.Controllers
{
    public class AttendencesController : Controller
    {
        private testDbEntities db = new testDbEntities();

        // GET: Attendences
        public ActionResult Index()
        {
            var tblAttendences = db.tblAttendences.Include(t => t.tblEmployee);
            return View(tblAttendences.ToList());
        }

        // GET: Attendences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAttendence tblAttendence = db.tblAttendences.Find(id);
            if (tblAttendence == null)
            {
                return HttpNotFound();
            }
            return View(tblAttendence);
        }

        // GET: Attendences/Create
        public ActionResult Create()
        {
            ViewBag.EmpCode = new SelectList(db.tblEmployees, "EmpCode", "EmpName");
            return View();
        }

        // POST: Attendences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpCode,AttDate,InHour,InMinute,OutHour,OutMinute,AttStatus,TotalRegularHour,Remarks")] tblAttendence tblAttendence)
        {
            if (ModelState.IsValid)
            {
                db.tblAttendences.Add(tblAttendence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpCode = new SelectList(db.tblEmployees, "EmpCode", "EmpName", tblAttendence.EmpCode);
            return View(tblAttendence);
        }

        // GET: Attendences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAttendence tblAttendence = db.tblAttendences.Find(id);
            if (tblAttendence == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpCode = new SelectList(db.tblEmployees, "EmpCode", "EmpName", tblAttendence.EmpCode);
            return View(tblAttendence);
        }

        // POST: Attendences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpCode,AttDate,InHour,InMinute,OutHour,OutMinute,AttStatus,TotalRegularHour,Remarks")] tblAttendence tblAttendence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAttendence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpCode = new SelectList(db.tblEmployees, "EmpCode", "EmpName", tblAttendence.EmpCode);
            return View(tblAttendence);
        }

        // GET: Attendences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAttendence tblAttendence = db.tblAttendences.Find(id);
            if (tblAttendence == null)
            {
                return HttpNotFound();
            }
            return View(tblAttendence);
        }

        // POST: Attendences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAttendence tblAttendence = db.tblAttendences.Find(id);
            db.tblAttendences.Remove(tblAttendence);
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
