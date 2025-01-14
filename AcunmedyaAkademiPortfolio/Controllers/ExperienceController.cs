using AcunmedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        DbAcunmedyaAkademi1Entities db = new DbAcunmedyaAkademi1Entities();
        public ActionResult Index()
        {
            var values = db.TblExperience.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateExperience(TblExperience tblExperience)
        {
            db.TblExperience.Add(tblExperience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            var value = db.TblExperience.Find(id);
            db.TblExperience.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var value = db.TblExperience.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateExperience(TblExperience tblExperience)
        {
            var value = db.TblExperience.Find(tblExperience.ExperienceID);
            value.Title = tblExperience.Title;
            value.Period = tblExperience.Period;
            value.Description = tblExperience.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}