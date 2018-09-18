using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using work_01.Models;
using System.Data.Entity;

namespace work_01.Controllers
{
    public class DepartmentController : Controller
    {
        testDbEntities db = new testDbEntities();
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDepartments()
        {
            var Department = db.tblDepartments.ToList();

            return Json(Department, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get(int DeptCode)
        {
            var deparment = db.tblDepartments.ToList().Find(x => x.DeptCode == DeptCode);
            return Json(deparment, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "DeptCode")] tblDepartment department)
        {
            if (ModelState.IsValid)
            {
                db.tblDepartments.Add(department);
                db.SaveChanges();

            }
            return Json(department, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Update(tblDepartment department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(department, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int DeptCode)
        {
            var deparment = db.tblDepartments.ToList().Find(x => x.DeptCode == DeptCode);
            if (deparment!=null)
            {
                db.tblDepartments.Remove(deparment);
                db.SaveChanges();
            }
            return Json(deparment, JsonRequestBehavior.AllowGet);
        }

    }
}