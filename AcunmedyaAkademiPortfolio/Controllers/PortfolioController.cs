using AcunmedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class PortfolioController : Controller
    {
        DbAcunmedyaAkademi1Entities db = new DbAcunmedyaAkademi1Entities();
        public ActionResult Index()
        {
            var values = db.TblProject.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreatePortfolio()
        {
            var categoryList = db.TblCategory.ToList();

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {

                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()

                                               }).ToList();
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult CreatePortfolio(TblProject tblProject)
        {
            var categoryList = db.TblCategory.ToList();

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {

                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()

                                               }).ToList();
            ViewBag.categories = categories;

            if (ModelState.IsValid)
            {
                db.TblProject.Add(tblProject);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(tblProject);
        }

        public ActionResult DeletePortfolio(int id)
        {
            var value = db.TblProject.Find(id);
            db.TblProject.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdatePortfolio(int id)
        {
            var categoryList = db.TblCategory.ToList();

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {

                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()

                                               }).ToList();
            ViewBag.categories = categories;
            var value = db.TblProject.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdatePortfolio(TblProject tblProject)
        {
            var categoryList = db.TblCategory.ToList();

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {

                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()

                                               }).ToList();
            ViewBag.categories = categories;

            var value = db.TblProject.Find(tblProject.ProjectID);
            value.ProjectTitle = tblProject.ProjectTitle;
            value.Description = tblProject.Description;
            value.CategoryID = tblProject.CategoryID;
            value.ImageUrl = tblProject.ImageUrl;

            if (!ModelState.IsValid)
            {
                return View(tblProject);
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}