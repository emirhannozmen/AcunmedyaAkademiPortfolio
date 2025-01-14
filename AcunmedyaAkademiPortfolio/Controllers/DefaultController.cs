using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using AcunmedyaAkademiPortfolio.Models;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        DbAcunmedyaAkademi1Entities db = new DbAcunmedyaAkademi1Entities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialHeroSection()
        {
            var values = db.TblSocialMedia.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialContacts()
        {
            return PartialView();
        }

        public PartialViewResult PartialEducation()
        {
            var values = db.TblEducation.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialExperience()
        {
            var values = db.TblExperience.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialServices()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }

        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        
        public PartialViewResult PartialStatistics()
        {
            ViewBag.SkillCount = db.TblSkills.Count();
            ViewBag.ProjectCount = db.TblProject.Count();
            ViewBag.ServiceCount = db.TblService.Count();
            ViewBag.MessageCount = db.TblMessage.Count();
            return PartialView();
        }
       
        public PartialViewResult PartialTestimonials()
        {

            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }
        
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialProjects()
        {
            var values = db.TblProject.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialFilters()
        {
            var values = db.TblCategory.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(TblMessage tblMessage)
        {
            db.TblMessage.Add(tblMessage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}