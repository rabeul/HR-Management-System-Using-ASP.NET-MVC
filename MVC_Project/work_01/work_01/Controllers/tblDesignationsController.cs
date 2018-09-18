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
    public class tblDesignationsController : Controller
    {
        private testDbEntities db = new testDbEntities();

        // GET: tblDesignations
        public ActionResult Index()
        {
            var tblDesignations = db.tblDesignations.Include(t => t.tblDepartment);
            return View(tblDesignations.ToList());
        }

        // GET: tblDesignations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDesignation tblDesignation = db.tblDesignations.Find(id);
            if (tblDesignation == null)
            {
                return HttpNotFound();
            }
            return View(tblDesignation);
        }

        // GET: tblDesignations/Create
        public ActionResult Create()
        {
            ViewBag.DeptCode = new SelectList(db.tblDepartments, "DeptCode", "DepartmentName");
            return View();
        }

        // POST: tblDesignations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DesigCode,Designation,DeptCode")] tblDesignation tblDesignation)
        {
            if (ModelState.IsValid)
            {
                db.tblDesignations.Add(tblDesignation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptCode = new SelectList(db.tblDepartments, "DeptCode", "DepartmentName", tblDesignation.DeptCode);
            return View(tblDesignation);
        }

        // GET: tblDesignations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDesignation tblDesignation = db.tblDesignations.Find(id);
            if (tblDesignation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptCode = new SelectList(db.tblDepartments, "DeptCode", "DepartmentName", tblDesignation.DeptCode);
            return View(tblDesignation);
        }

        // POST: tblDesignations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DesigCode,Designation,DeptCode")] tblDesignation tblDesignation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDesignation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptCode = new SelectList(db.tblDepartments, "DeptCode", "DepartmentName", tblDesignation.DeptCode);
            return View(tblDesignation);
        }

        // GET: tblDesignations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDesignation tblDesignation = db.tblDesignations.Find(id);
            if (tblDesignation == null)
            {
                return HttpNotFound();
            }
            return View(tblDesignation);
        }

        // POST: tblDesignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDesignation tblDesignation = db.tblDesignations.Find(id);
            db.tblDesignations.Remove(tblDesignation);
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
