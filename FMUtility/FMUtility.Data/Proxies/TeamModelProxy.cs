using System.Collections.Generic;
using System.Linq;
using FMEditorLive;
using FMEditorLive.FMObjects;
using FMUtility.Data.Mappers;
using FMUtility.Models;

namespace FMUtility.Data.Proxies
{
    public class TeamModelProxy : TeamModel
    {
        private readonly IFmContext _fmContext;
        private readonly IMatchPreparationModelMapper _matchPreparationModelMapper;
        private readonly IStadiumMapper _stadiumMapper;
        private readonly Team _team;
        private List<MatchPreparationModel> _matchPreparations;
        private List<PlayerModel> _players;
        private StadiumModel _stadium;

        public TeamModelProxy(Team team) : this(team, FmContext.Instance)
        {
        }

        public TeamModelProxy(Team team, IFmContext fmContext)
        {
            _stadiumMapper = new StadiumMapper();
            _matchPreparationModelMapper = new MatchPreparationModelMapper();
            _team = team;
            _fmContext = fmContext;
        }

        public override List<MatchPreparationModel> MatchPreparations
        {
            get { return _matchPreparations ?? (_matchPreparations = MapMatchPreparation(_team.MatchPreparation)); }
            set { _matchPreparations = value; }
        }

        public override List<PlayerModel> Players
        {
            get { return _players ?? (_players = MapPlayers(_team.Players)); }
            set { _players = value; }
        }

        public override StadiumModel StadiumModel
        {
            get { return _stadium ?? (_stadium = _stadiumMapper.Map(_team.Stadium)); }
            set { _stadium = value; }
        }

        private List<PlayerModel> MapPlayers(IEnumerable<Player> players)
        {
            return players.Select(p => _fmContext.Players.Single(pm => p.ID == pm.Id)).ToList();
        }

        private List<MatchPreparationModel> MapMatchPreparation(IEnumerable<MatchPreparation> matchPreparations)
        {
            return matchPreparations.Select(_matchPreparationModelMapper.Map).ToList();
        }
    }
}