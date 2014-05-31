using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMUtility.Core.Threading;
using FMUtility.Data.Mappers;
using FMUtility.Data.Queries;
using FMUtility.Models;
using FMUtility.Models.Dtos;
using TaskFactory = FMUtility.Core.Threading.TaskFactory;

namespace FMUtility.Data.Gateways
{
    public interface IPlayerGateway
    {
        Task<List<PlayerSimple>> Get(IQuery<PlayerModel> query);
        Task<PlayerModel> Get(int id);
    }

    public class PlayerGateway : IPlayerGateway
    {
        private readonly IFmContext _fmContext;
        private readonly IPlayerSimpleMapper _playerSimpleMapper;
        private readonly ITaskFactory _taskFactory;

        public PlayerGateway() : this(FmContext.Instance, new PlayerSimpleMapper(), TaskFactory.Instance)
        {
        }

        public PlayerGateway(IFmContext fmContext, IPlayerSimpleMapper playerSimpleMapper, ITaskFactory taskFactory)
        {
            _fmContext = fmContext;
            _playerSimpleMapper = playerSimpleMapper;
            _taskFactory = taskFactory;
        }

        public Task<List<PlayerSimple>> Get(IQuery<PlayerModel> query)
        {
            return _taskFactory.StartNew(() => _fmContext.Players.Where(query.IsMatch).Select(_playerSimpleMapper.Map).ToList(), "Query players in game...");
        }

        public Task<PlayerModel> Get(int id)
        {
            return _taskFactory.StartNew(() => _fmContext.Players.SingleOrDefault(p => p.Id == id), "Getting player...");
        }
    }
}