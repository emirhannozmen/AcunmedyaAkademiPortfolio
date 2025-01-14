using AcunmedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class MessageController : Controller
    {
        DbAcunmedyaAkademi1Entities db = new DbAcunmedyaAkademi1Entities();
        public ActionResult Index()
        {
            var values = db.TblMessage.ToList();
            return View(values);
        }
        public ActionResult DeleteMessage(int id)
        {
            var value = db.TblMessage.Find(id);
            db.TblMessage.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReadToTrue(int id)
        {
            var value = db.TblMessage.Find(id);
            value.Status = "Okundu";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReadToFalse(int id)
        {
            var value = db.TblMessage.Find(id);
            value.Status = "Okunmadı";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}