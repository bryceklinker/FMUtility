using System.Web.Http;
using System.Web.Http.Results;

namespace FMUtility.Server.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public JsonResult<string> Index()
        {
            return Json("OK");
        }
    }
}
