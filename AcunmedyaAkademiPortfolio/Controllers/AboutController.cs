using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunmedyaAkademiPortfolio.Models;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class AboutController : Controller
    {
        DbAcunmedyaAkademi1Entities db = new DbAcunmedyaAkademi1Entities();
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(TblAbout tblAbout)
        {
            db.TblAbout.Add(tblAbout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAbout(int id)
        {
            var value = db.TblAbout.Find(id);
            db.TblAbout.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = db.TblAbout.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout tblAbout)
        {
            var value = db.TblAbout.Find(tblAbout.AboutID);

            value.Title = tblAbout.Title;
            value.Description = tblAbout.Description;
            value.ImageUrl = tblAbout.ImageUrl;
            value.Age = tblAbout.Age;
            value.Email = tblAbout.Email;
            value.Birthday = tblAbout.Birthday;
            value.Location = tblAbout.Location;
            value.Phone = tblAbout.Phone;
            value.Website = tblAbout.Website;
            value.Degree = tblAbout.Degree;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}