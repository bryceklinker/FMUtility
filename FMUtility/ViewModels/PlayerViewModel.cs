﻿using FMUtility.Gateways;
using FMUtility.Models;

namespace FMUtility.ViewModels
{
    public class PlayerViewModel : DocumentViewModel
    {
        private readonly IPlayerGateway _playerGateway;
        private readonly int _playerId;
        private PlayerModel _playerModel;

        public string FirstName
        {
            get
            {
                EnsurePlayer();
                return _playerModel.FirstName;
            }
        }

        public string LastName
        {
            get
            {
                EnsurePlayer(); 
                return _playerModel.LastName;
            }
        }

        public int CurrentAbility
        {
            get
            {
                EnsurePlayer(); 
                return _playerModel.CurrentAbility;
            }
        }

        public int PotentialAbility
        {
            get
            {
                EnsurePlayer();
                return _playerModel.PotentialAbility;
            }
        }

        public override string Title
        {
            get
            {
                EnsurePlayer();
                return string.Format("{0} {1}", _playerModel.FirstName, _playerModel.LastName);
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

        private void EnsurePlayer()
        {
            if (_playerModel == null)
                _playerModel = _playerGateway.Get(_playerId);
        }
    }
}
