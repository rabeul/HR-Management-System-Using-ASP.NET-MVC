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
    public class BenefitsController : Controller
    {
        private testDbEntities db = new testDbEntities();

        // GET: Benefits
        public ActionResult Index()
        {
            var tblBenefits = db.tblBenefits.Include(t => t.tblEmployee);
            return View(tblBenefits.ToList());
        }

        // GET: Benefits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBenefit tblBenefit = db.tblBenefits.Find(id);
            if (tblBenefit == null)
            {
                return HttpNotFound();
            }
            return View(tblBenefit);
        }

        // GET: Benefits/Create
        public ActionResult Create()
        {
            ViewBag.EmpCode = new SelectList(db.tblEmployees, "EmpCode", "EmpName");
            return View();
        }

        // POST: Benefits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BenefitCode,EmpCode,BenefitAmount,BenefitDate,BenefitType,PreviousNetSalary,NewNetSalary,Gross,Basic,HouseRent,Medical,ConvenceAll,CashIntensive,launceAllowance,otherAllowance,StateStatus,BenifitActiveDate,Remarks")] tblBenefit tblBenefit)
        {
            if (ModelState.IsValid)
            {
                db.tblBenefits.Add(tblBenefit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpCode = new SelectList(db.tblEmployees, "EmpCode", "EmpName", tblBenefit.EmpCode);
            return View(tblBenefit);
        }

        // GET: Benefits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBenefit tblBenefit = db.tblBenefits.Find(id);
            if (tblBenefit == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpCode = new SelectList(db.tblEmployees, "EmpCode", "EmpName", tblBenefit.EmpCode);
            return View(tblBenefit);
        }

        // POST: Benefits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BenefitCode,EmpCode,BenefitAmount,BenefitDate,BenefitType,PreviousNetSalary,NewNetSalary,Gross,Basic,HouseRent,Medical,ConvenceAll,CashIntensive,launceAllowance,otherAllowance,StateStatus,BenifitActiveDate,Remarks")] tblBenefit tblBenefit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBenefit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpCode = new SelectList(db.tblEmployees, "EmpCode", "EmpName", tblBenefit.EmpCode);
            return View(tblBenefit);
        }

        // GET: Benefits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBenefit tblBenefit = db.tblBenefits.Find(id);
            if (tblBenefit == null)
            {
                return HttpNotFound();
            }
            return View(tblBenefit);
        }

        // POST: Benefits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBenefit tblBenefit = db.tblBenefits.Find(id);
            db.tblBenefits.Remove(tblBenefit);
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
