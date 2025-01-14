using AcunmedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class EducationController : Controller
    {
        DbAcunmedyaAkademi1Entities db = new DbAcunmedyaAkademi1Entities();
        public ActionResult Index()
        {
            var values = db.TblEducation.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(TblEducation tblEducation)
        {
            db.TblEducation.Add(tblEducation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            var value = db.TblEducation.Find(id);
            db.TblEducation.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = db.TblEducation.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateEducation(TblEducation tblEducation)
        {
            var value = db.TblEducation.Find(tblEducation.EducationID);

            value.Title = tblEducation.Title;
            value.SubTitle = tblEducation.SubTitle;
            value.Period = tblEducation.Period;
            value.Description = tblEducation.Description;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}