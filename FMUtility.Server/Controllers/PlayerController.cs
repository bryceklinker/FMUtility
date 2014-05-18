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
    public class PlayerController : ApiController
    {
        private readonly IPlayerGateway _playerGateway;

        public PlayerController() : this(new PlayerGateway())
        {

        }

        public PlayerController(IPlayerGateway playerGateway)
        {
            _playerGateway = playerGateway;
        }

        [HttpGet]
        public JsonResult<PlayerModel> Get(int id)
        {
            var player = _playerGateway.Get(id).Result;
            return Json(player);
        }

        [HttpGet]
        public JsonResult<List<PlayerModel>> Search([ModelBinder(typeof(PlayerSearchArgsBinder))] PlayerSearchArgs args)
        {
            var query = new PlayerSearchQuery(args);
            var players = _playerGateway.Get(query).Result;
            return Json(players);
        }
    }
}
