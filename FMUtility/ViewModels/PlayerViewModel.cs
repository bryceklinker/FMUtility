using System.Collections.Generic;
using System.Linq;
using FMUtility.Gateways;
using FMUtility.Models;

namespace FMUtility.ViewModels
{
    public class PlayerViewModel : DocumentViewModel
    {
        private bool _isLoadingPlayer;
        private readonly IPlayerGateway _playerGateway;
        private readonly int _playerId;
        private PlayerModel _playerModel;

        public string FirstName
        {
            get
            {
                EnsurePlayer();
                return _isLoadingPlayer ? null : _playerModel.FirstName;
            }
        }

        public string LastName
        {
            get
            {
                EnsurePlayer();
                return _isLoadingPlayer ? null : _playerModel.LastName;
            }
        }

        public int CurrentAbility
        {
            get
            {
                EnsurePlayer(); 
                return _isLoadingPlayer ? 0 : _playerModel.CurrentAbility;
            }
        }

        public int PotentialAbility
        {
            get
            {
                EnsurePlayer();
                return _isLoadingPlayer ? 0 : _playerModel.PotentialAbility;
            }
        }

        public override string Title
        {
            get
            {
                EnsurePlayer();
                return _isLoadingPlayer ? "Loading Player..." : string.Format("{0} {1}", _playerModel.FirstName, _playerModel.LastName);
            }
        }

        public bool IsGoalKeeper
        {
            get
            {
                EnsurePlayer();
                return !_isLoadingPlayer && _playerModel.Positions.Any(p => p.Area == Area.Goalkeeping && p.Value > 1);
            }
        }

        public IEnumerable<AttributeModel> Technical
        {
            get
            {
                EnsurePlayer();
                return _isLoadingPlayer ? null : _playerModel.Techincal;
            }
        }

        public IEnumerable<AttributeModel> Mental
        {
            get
            {
                EnsurePlayer();
                return _isLoadingPlayer ? null : _playerModel.Mental;
            }
        }

        public IEnumerable<AttributeModel> Physical
        {
            get
            {
                EnsurePlayer();
                return _isLoadingPlayer ? null : _playerModel.Physical;
            }
        }

        public IEnumerable<AttributeModel> Hidden
        {
            get
            {
                EnsurePlayer();
                return _isLoadingPlayer ? null : _playerModel.Hidden;
            }
        }

        public IEnumerable<AttributeModel> Goalkeeping
        {
            get
            {
                EnsurePlayer();
                return _isLoadingPlayer ? null : _playerModel.GoalKeeping;
            }
        }

        public PlayerViewModel(int playerId) : this(playerId, new PlayerGateway())
        {
            
        }

        public PlayerViewModel(int playerId, IPlayerGateway playerGateway)
        {
            _playerGateway = playerGateway;
            _playerId = playerId;
        }

        private async void EnsurePlayer()
        {
            if (_playerModel == null
                && !_isLoadingPlayer)
            {
                _isLoadingPlayer = true;
                _playerModel = await _playerGateway.Get(_playerId);
                _isLoadingPlayer = false;
                FinishEnsurePlayer();
            }
        }

        private void FinishEnsurePlayer()
        {
            _isLoadingPlayer = false;
            RaisePropertyChanged(() => CurrentAbility);
            RaisePropertyChanged(() => FirstName);
            RaisePropertyChanged(() => Goalkeeping);
            RaisePropertyChanged(() => Hidden);
            RaisePropertyChanged(() => IsGoalKeeper);
            RaisePropertyChanged(() => LastName);
            RaisePropertyChanged(() => Mental);
            RaisePropertyChanged(() => Physical);
            RaisePropertyChanged(() => PotentialAbility);
            RaisePropertyChanged(() => Technical);
            RaisePropertyChanged(() => Title);
        }
    }
}
