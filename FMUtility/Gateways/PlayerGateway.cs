using System.Collections.Generic;
using System.Linq;
using FMUtility.Models;

namespace FMUtility.Gateways
{
    public interface IPlayerGateway
    {
        IEnumerable<PlayerModel> Get(IQuery<PlayerModel> query);
    }

    public class PlayerGateway : IPlayerGateway
    {
        private readonly IFmContext _fmContext;

        public PlayerGateway(IFmContext fmContext)
        {
            _fmContext = fmContext;
        }

        public IEnumerable<PlayerModel> Get(IQuery<PlayerModel> query)
        {
            return _fmContext.Players.Where(query.IsMatch);
        }
    }
}
