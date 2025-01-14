using AcunmedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        DbAcunmedyaAkademi1Entities db = new DbAcunmedyaAkademi1Entities();
        public ActionResult Index()
        {
            var values = db.TblTestimonial.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(TblTestimonial tblTestimonial)
        {
            db.TblTestimonial.Add(tblTestimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.TblTestimonial.Find(id);
            db.TblTestimonial.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.TblTestimonial.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial tblTestimonial)
        {
            var value = db.TblTestimonial.Find(tblTestimonial.TestimonialID);
            value.NameSurname = tblTestimonial.NameSurname;
            value.Title = tblTestimonial.Title;
            value.CommentDetail = tblTestimonial.CommentDetail;
            value.ImageUrl = tblTestimonial.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}