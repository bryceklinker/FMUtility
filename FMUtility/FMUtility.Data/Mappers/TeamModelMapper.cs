using System.Collections.Generic;
using System.Linq;
using FMEditorLive.FMObjects;
using FMUtility.Data.Extensions;
using FMUtility.Data.Proxies;
using FMUtility.Models;

namespace FMUtility.Data.Mappers
{
    public interface ITeamModelMapper
    {
        List<TeamModel> Map(IEnumerable<Team> teams);
        TeamModelProxy Map(Team t);
    }

    public class TeamModelMapper : ITeamModelMapper
    {
        private readonly ClubModel _club;

        public TeamModelMapper(ClubModel club)
        {
            _club = club;
        }

        public List<TeamModel> Map(IEnumerable<Team> teams)
        {
            return teams.Select(Map).ToList<TeamModel>();
        }

        public TeamModelProxy Map(Team t)
        {
            return new TeamModelProxy(t)
            {
                Club = _club,
                ManagerId = t.Manager.ID,
                ManagerName = t.Manager.Name,
                Name = t.Name,
                Reputation = t.Reputation,
                TeamType = t.TeamType.AsTeamType(),
                TypeTypeNum = t.TypeTypeNum
            };
        }
    }
}