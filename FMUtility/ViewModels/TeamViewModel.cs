using System.Collections.Generic;
using System.Windows.Input;
using FMUtility.Commands;
using FMUtility.Models;

namespace FMUtility.ViewModels
{
    public class TeamViewModel : ViewModelBase
    {
        private readonly ViewPlayerCommand _viewPlayer;
        private readonly TeamModel _teamModel;

        public ICommand ViewPlayer
        {
            get { return _viewPlayer; }
        }

        public List<PlayerModel> Players
        {
            get { return _teamModel.Players; }
        }

        public string Name
        {
            get { return _teamModel.Name; }
        }

        public TeamViewModel(TeamModel teamModel)
        {
            _teamModel = teamModel;
            _viewPlayer = new ViewPlayerCommand();
        }
    }
}
