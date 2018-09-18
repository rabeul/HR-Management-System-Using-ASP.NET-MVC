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
    public class EmployeesController : Controller
    {
        private testDbEntities db = new testDbEntities();

        // GET: Employees
        public ActionResult Index()
        {
            var tblEmployees = db.tblEmployees.Include(t => t.tblDepartment).Include(t => t.tblDesignation).Include(t => t.tblDivision).Include(t => t.tblEmployeeType).Include(t => t.tblSection);
            return View(tblEmployees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DeptCode = new SelectList(db.tblDepartments, "DeptCode", "DepartmentName");
            ViewBag.DesigCode = new SelectList(db.tblDesignations, "DesigCode", "Designation");
            ViewBag.DivCode = new SelectList(db.tblDivisions, "DivCode", "Division");
            ViewBag.EmpTypeCode = new SelectList(db.tblEmployeeTypes, "EmpTypecode", "EmpType");
            ViewBag.SecCode = new SelectList(db.tblSections, "SecCode", "SectionName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpCode,EmpName,Address,Email,DOB,FatherName,MotherName,ContactNo,Gender,Nationality,Religion,NID,JoiningDate,DeptCode,DesigCode,SecCode,DivCode,EmpTypeCode,CurrentSalary,AccNo,BankName")] tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                db.tblEmployees.Add(tblEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptCode = new SelectList(db.tblDepartments, "DeptCode", "DepartmentName", tblEmployee.DeptCode);
            ViewBag.DesigCode = new SelectList(db.tblDesignations, "DesigCode", "Designation", tblEmployee.DesigCode);
            ViewBag.DivCode = new SelectList(db.tblDivisions, "DivCode", "Division", tblEmployee.DivCode);
            ViewBag.EmpTypeCode = new SelectList(db.tblEmployeeTypes, "EmpTypecode", "EmpType", tblEmployee.EmpTypeCode);
            ViewBag.SecCode = new SelectList(db.tblSections, "SecCode", "SectionName", tblEmployee.SecCode);
            return View(tblEmployee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptCode = new SelectList(db.tblDepartments, "DeptCode", "DepartmentName", tblEmployee.DeptCode);
            ViewBag.DesigCode = new SelectList(db.tblDesignations, "DesigCode", "Designation", tblEmployee.DesigCode);
            ViewBag.DivCode = new SelectList(db.tblDivisions, "DivCode", "Division", tblEmployee.DivCode);
            ViewBag.EmpTypeCode = new SelectList(db.tblEmployeeTypes, "EmpTypecode", "EmpType", tblEmployee.EmpTypeCode);
            ViewBag.SecCode = new SelectList(db.tblSections, "SecCode", "SectionName", tblEmployee.SecCode);
            return View(tblEmployee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpCode,EmpName,Address,Email,DOB,FatherName,MotherName,ContactNo,Gender,Nationality,Religion,NID,JoiningDate,DeptCode,DesigCode,SecCode,DivCode,EmpTypeCode,CurrentSalary,AccNo,BankName")] tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptCode = new SelectList(db.tblDepartments, "DeptCode", "DepartmentName", tblEmployee.DeptCode);
            ViewBag.DesigCode = new SelectList(db.tblDesignations, "DesigCode", "Designation", tblEmployee.DesigCode);
            ViewBag.DivCode = new SelectList(db.tblDivisions, "DivCode", "Division", tblEmployee.DivCode);
            ViewBag.EmpTypeCode = new SelectList(db.tblEmployeeTypes, "EmpTypecode", "EmpType", tblEmployee.EmpTypeCode);
            ViewBag.SecCode = new SelectList(db.tblSections, "SecCode", "SectionName", tblEmployee.SecCode);
            return View(tblEmployee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            db.tblEmployees.Remove(tblEmployee);
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
