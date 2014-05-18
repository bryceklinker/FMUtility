using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;
using FMUtility.Core.Eventing.Args;
using FMUtility.Data.Gateways;
using FMUtility.Data.Queries;
using FMUtility.Models;
using FMUtility.Server.Binders;

namespace FMUtility.Server.Controllers
{
    public class ClubController : ApiController
    {
        private readonly IClubGateway _clubGateway;

        public ClubController() : this(new ClubGateway())
        {

        }

        public ClubController(IClubGateway clubGateway)
        {
            _clubGateway = clubGateway;
        }

        [HttpGet]
        public JsonResult<ClubModel> Get(int id)
        {
            var club = _clubGateway.Get(id).Result;
            return Json(club);
        }

        [HttpGet]
        public JsonResult<List<ClubModel>> Search([ModelBinder(typeof(ClubSearchArgsBinder))]ClubSearchArgs args)
        {
            var query = new ClubSearchQuery(args);
            var clubs = _clubGateway.Get(query).Result;
            return Json(clubs);
        }
    }
}
