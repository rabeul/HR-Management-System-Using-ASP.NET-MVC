using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using work_01.Models;
using System.Data.Entity;

namespace work_01.Controllers
{
    public class EmployeeTypeController : Controller
    {
        testDbEntities db = new testDbEntities();
        // GET: EmployeeType
        public ActionResult Index()
        {
            return View();
        }

        //get type
        public ActionResult GetEmployeeTypes()
        {
            var employeeType = db.tblEmployeeTypes.ToList();
            return Json(employeeType, JsonRequestBehavior.AllowGet);
        }

        //get EmployeeType by ETCode
        public ActionResult Get(int id)
        {
            var employeeType = db.tblEmployeeTypes.ToList().Find(e => e.EmpTypecode == id);
            return Json(employeeType, JsonRequestBehavior.AllowGet);
        }

        //create EmployeeType
        [HttpPost]
        public ActionResult Create([Bind(Exclude="EmpTypecode")]tblEmployeeType employeeType)
        {
            if (ModelState.IsValid)
            {
                db.tblEmployeeTypes.Add(employeeType);
                db.SaveChanges();
            }
            return Json(employeeType, JsonRequestBehavior.AllowGet);
        }

        //Update
        [HttpPost]
        public ActionResult Update(tblEmployeeType employeeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeType).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(employeeType, JsonRequestBehavior.AllowGet);
        }

        //Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var employeeType = db.tblEmployeeTypes.ToList().Find(e => e.EmpTypecode == id);
            if (employeeType != null)
            {
                db.tblEmployeeTypes.Remove(employeeType);
                db.SaveChanges();
            }
            return Json(employeeType, JsonRequestBehavior.AllowGet);
        }
    }
}