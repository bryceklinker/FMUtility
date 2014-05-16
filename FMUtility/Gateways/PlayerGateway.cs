using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMUtility.Models;
using FMUtility.Threading;

namespace FMUtility.Gateways
{
    public interface IPlayerGateway
    {
        Task<List<PlayerModel>> Get(IQuery<PlayerModel> query);
        Task<PlayerModel> Get(int id);
    }

    public class PlayerGateway : IPlayerGateway
    {
        private readonly IFmContext _fmContext;
        private readonly ITaskFactory _taskFactory;

        public PlayerGateway() : this(FmContext.Instance, Threading.TaskFactory.Instance)
        {

        }

        public PlayerGateway(IFmContext fmContext, ITaskFactory taskFactory)
        {
            _fmContext = fmContext;
            _taskFactory = taskFactory;
        }

        public Task<List<PlayerModel>> Get(IQuery<PlayerModel> query)
        {
            return _taskFactory.StartNew(() => _fmContext.Players.Where(query.IsMatch).ToList(), "Query players in game...");
        }

        public Task<PlayerModel> Get(int id)
        {
            return _taskFactory.StartNew(() => _fmContext.Players.SingleOrDefault(p => p.Id == id), "Getting player...");
        }
    }
}
