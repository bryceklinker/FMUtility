using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMUtility.Core.Threading;
using FMUtility.Data.Queries;
using FMUtility.Models;
using TaskFactory = FMUtility.Core.Threading.TaskFactory;

namespace FMUtility.Data
{
    public interface IClubGateway
    {
        Task<List<ClubModel>> Get(IQuery<ClubModel> query);
        Task<ClubModel> Get(int id);
    }

    public class ClubGateway : IClubGateway
    {
        private readonly IFmContext _fmContext;
        private readonly ITaskFactory _taskFactory;

        public ClubGateway() : this(FmContext.Instance, TaskFactory.Instance)
        {
        }

        public ClubGateway(IFmContext fmContext, ITaskFactory taskFactory)
        {
            _fmContext = fmContext;
            _taskFactory = taskFactory;
        }

        public Task<List<ClubModel>> Get(IQuery<ClubModel> query)
        {
            return _taskFactory.StartNew(() => _fmContext.Clubs.Where(query.IsMatch).ToList());
        }

        public Task<ClubModel> Get(int id)
        {
            return _taskFactory.StartNew(() => _fmContext.Clubs.SingleOrDefault(c => c.Id == id));
        }
    }
}