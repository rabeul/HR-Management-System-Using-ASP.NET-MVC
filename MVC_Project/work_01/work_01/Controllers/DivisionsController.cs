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
    public class DivisionsController : Controller
    {
        private testDbEntities db = new testDbEntities();

        // GET: Divisions
        public ActionResult Index()
        {
            return View(db.tblDivisions.ToList());
        }

        // GET: Divisions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDivision tblDivision = db.tblDivisions.Find(id);
            if (tblDivision == null)
            {
                return HttpNotFound();
            }
            return View(tblDivision);
        }

        // GET: Divisions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Divisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DivCode,Division")] tblDivision tblDivision)
        {
            if (ModelState.IsValid)
            {
                db.tblDivisions.Add(tblDivision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDivision);
        }

        // GET: Divisions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDivision tblDivision = db.tblDivisions.Find(id);
            if (tblDivision == null)
            {
                return HttpNotFound();
            }
            return View(tblDivision);
        }

        // POST: Divisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DivCode,Division")] tblDivision tblDivision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDivision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDivision);
        }

        // GET: Divisions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDivision tblDivision = db.tblDivisions.Find(id);
            if (tblDivision == null)
            {
                return HttpNotFound();
            }
            return View(tblDivision);
        }

        // POST: Divisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDivision tblDivision = db.tblDivisions.Find(id);
            db.tblDivisions.Remove(tblDivision);
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
