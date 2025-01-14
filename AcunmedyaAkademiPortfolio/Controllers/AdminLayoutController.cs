using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class AdminLayoutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
    }
}