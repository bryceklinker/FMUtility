using System.Collections.Generic;
using FMEditorLive;
using FMUtility.Data.Mappers;
using FMUtility.Models;

namespace FMUtility.Data.Proxies
{
    public class ClubModelProxy : ClubModel
    {
        private readonly Club _club;
        private readonly IFinancesModelMapper _financesModelMapper;
        private readonly IKitModelMapper _kitModelMapper;
        private readonly ITeamModelMapper _teamModelMapper;
        private FinancesModel _finances;
        private List<KitModel> _kits;
        private List<TeamModel> _teams;

        public ClubModelProxy(Club club)
        {
            _club = club;
            _kitModelMapper = new KitModelMapper();
            _financesModelMapper = new FinancesModelMapper();
            _teamModelMapper = new TeamModelMapper(this);
        }

        public override FinancesModel Finances
        {
            get { return _finances ?? (_finances = _financesModelMapper.Map(_club.Finances)); }
            set { _finances = value; }
        }

        public override List<KitModel> Kits
        {
            get { return _kits ?? (_kits = _kitModelMapper.Map(_club.Kits)); }
            set { _kits = value; }
        }

        public override List<TeamModel> Teams
        {
            get { return _teams ?? (_teams = _teamModelMapper.Map(_club.Teams)); }
            set { _teams = value; }
        }
    }
}