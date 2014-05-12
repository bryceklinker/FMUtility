using System.Collections.Generic;
using System.Linq;
using FMUtility.Models;

namespace FMUtility.Gateways
{
    public interface IPlayerGateway
    {
        IEnumerable<PlayerModel> Get(IQuery<PlayerModel> query);
        PlayerModel Get(int id);
    }

    public class PlayerGateway : IPlayerGateway
    {
        private readonly IFmContext _fmContext;

        public PlayerGateway() : this(FmContext.Instance)
        {

        }

        public PlayerGateway(IFmContext fmContext)
        {
            _fmContext = fmContext;
        }

        public IEnumerable<PlayerModel> Get(IQuery<PlayerModel> query)
        {
            return _fmContext.Players.Where(query.IsMatch);
        }

        public PlayerModel Get(int id)
        {
            return _fmContext.Players.SingleOrDefault(p => p.Id == id);
        }
    }
}
