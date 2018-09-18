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
    public class TransferInfoesController : Controller
    {
        private testDbEntities db = new testDbEntities();

        // GET: TransferInfoes
        public ActionResult Index()
        {
            var tbleTransferInfoes = db.tbleTransferInfoes.Include(t => t.tblEmployee);
            return View(tbleTransferInfoes.ToList());
        }

        // GET: TransferInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbleTransferInfo tbleTransferInfo = db.tbleTransferInfoes.Find(id);
            if (tbleTransferInfo == null)
            {
                return HttpNotFound();
            }
            return View(tbleTransferInfo);
        }

        // GET: TransferInfoes/Create
        public ActionResult Create()
        {
            ViewBag.EmpCode = new SelectList(db.tblEmployees, "EmpCode", "EmpName");
            return View();
        }

        // POST: TransferInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TRCode,TRDate,OldDeptCode,NewDeptCode,OldDesignationCode,NewDesigtnationCode,OldSecCode,NewSecCode,OldDivCode,NewDivCode,TrActivateDate,EmpCode,StateStatus,Remarks,EmpName")] tbleTransferInfo tbleTransferInfo)
        {
            if (ModelState.IsValid)
            {
                db.tbleTransferInfoes.Add(tbleTransferInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpCode = new SelectList(db.tblEmployees, "EmpCode", "EmpName", tbleTransferInfo.EmpCode);
            return View(tbleTransferInfo);
        }

        // GET: TransferInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbleTransferInfo tbleTransferInfo = db.tbleTransferInfoes.Find(id);
            if (tbleTransferInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpCode = new SelectList(db.tblEmployees, "EmpCode", "EmpName", tbleTransferInfo.EmpCode);
            return View(tbleTransferInfo);
        }

        // POST: TransferInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TRCode,TRDate,OldDeptCode,NewDeptCode,OldDesignationCode,NewDesigtnationCode,OldSecCode,NewSecCode,OldDivCode,NewDivCode,TrActivateDate,EmpCode,StateStatus,Remarks,EmpName")] tbleTransferInfo tbleTransferInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbleTransferInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpCode = new SelectList(db.tblEmployees, "EmpCode", "EmpName", tbleTransferInfo.EmpCode);
            return View(tbleTransferInfo);
        }

        // GET: TransferInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbleTransferInfo tbleTransferInfo = db.tbleTransferInfoes.Find(id);
            if (tbleTransferInfo == null)
            {
                return HttpNotFound();
            }
            return View(tbleTransferInfo);
        }

        // POST: TransferInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbleTransferInfo tbleTransferInfo = db.tbleTransferInfoes.Find(id);
            db.tbleTransferInfoes.Remove(tbleTransferInfo);
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
