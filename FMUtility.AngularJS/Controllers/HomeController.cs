using System.Web.Mvc;

namespace FMUtility.AngularJS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}