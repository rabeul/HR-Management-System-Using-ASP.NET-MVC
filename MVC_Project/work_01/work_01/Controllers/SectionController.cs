using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using work_01.Models;
using System.Data.Entity;

namespace work_01.Controllers
{
    public class SectionController : Controller
    {
        testDbEntities db = new testDbEntities();
        // GET: Section
        public ActionResult Index()
        {
            return View();
        }

        //get Sections list
        public ActionResult GetSection()
        {
            var tblSection = db.tblSections.ToList();
            return Json(tblSection, JsonRequestBehavior.AllowGet);
        }
        //get Sections By Code
        public ActionResult Get(int Code)
        {
            var section = db.tblSections.ToList().Find(s => s.SecCode == Code);
            return Json(section, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(tblSection section)
        {
            if (ModelState.IsValid)
            {
                db.tblSections.Add(section);
                db.SaveChanges();
            }
            return Json(section, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int Code)
        {
            var section = db.tblSections.ToList().Find(s => s.SecCode == Code);
            if (section != null)
            {
                db.tblSections.Remove(section);
                db.SaveChanges();
            }
            return Json(section, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(tblSection section)
        {
            if (ModelState.IsValid)
            {
                db.Entry(section).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(section, JsonRequestBehavior.AllowGet);
        }
    }
}