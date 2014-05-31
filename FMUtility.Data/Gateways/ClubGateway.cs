using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMUtility.Core.Threading;
using FMUtility.Data.Extensions;
using FMUtility.Data.Mappers;
using FMUtility.Data.Queries;
using FMUtility.Models;
using FMUtility.Models.Dtos;
using TaskFactory = FMUtility.Core.Threading.TaskFactory;

namespace FMUtility.Data.Gateways
{
    public interface IClubGateway
    {
        Task<List<ClubSimple>> Get(IQuery<ClubModel> query);
        Task<ClubModel> Get(int id);
    }

    public class ClubGateway : IClubGateway
    {
        private readonly IFmContext _fmContext;
        private readonly IClubSimpleMapper _clubSimpleMapper;
        private readonly ITaskFactory _taskFactory;

        public ClubGateway() : this(FmContext.Instance, new ClubSimpleMapper(), TaskFactory.Instance)
        {
        }

        public ClubGateway(IFmContext fmContext, IClubSimpleMapper clubSimpleMapper, ITaskFactory taskFactory)
        {
            _fmContext = fmContext;
            _clubSimpleMapper = clubSimpleMapper;
            _taskFactory = taskFactory;
        }

        public Task<List<ClubSimple>> Get(IQuery<ClubModel> query)
        {
            return _taskFactory.StartNew(() => _fmContext.Clubs.Where(query.IsMatch).Select(_clubSimpleMapper.Map).ToList());
        }

        public Task<ClubModel> Get(int id)
        {
            return _taskFactory.StartNew(() => _fmContext.Clubs.SingleOrDefault(c => c.Id == id));
        }
    }
}