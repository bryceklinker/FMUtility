using FMUtility.Gateways;
using FMUtility.Models;

namespace FMUtility.ViewModels
{
    public class PlayerViewModel : DocumentViewModel
    {
        private readonly PlayerModel _playerModel;

        public string FirstName
        {
            get { return _playerModel.FirstName; }
        }

        public string LastName
        {
            get { return _playerModel.LastName; }
        }

        public int CurrentAbility
        {
            get { return _playerModel.CurrentAbility; }
        }

        public int PotentialAbility
        {
            get { return _playerModel.PotentialAbility; }
        }

        public PlayerViewModel(int playerId) : this(playerId, new PlayerGateway())
        {
            
        }

        public PlayerViewModel(int playerId, IPlayerGateway playerGateway)
        {
            _playerModel = playerGateway.Get(playerId);
        }

        public override string Title
        {
            get { return string.Format("{0} {1}", _playerModel.FirstName, _playerModel.LastName); }
        }
    }
}
