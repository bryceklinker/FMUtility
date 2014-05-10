using System.Collections.Generic;
using System.Linq;
using FMEditorLive.FMObjects;
using FMUtility.Gateways.Mappers;
using FMUtility.Models;
using ProgressBar = System.Windows.Forms.ProgressBar;

namespace FMUtility.Gateways
{
    public interface IFmContext
    {
        List<PlayerModel> Players { get; }
    }

    public class FmContext : IFmContext
    {
        private readonly IPlayerModelMapper _playerMapper;
        private bool _isGameLoaded;
        private List<PlayerModel> _playerModels; 

        public FmContext() : this(new PlayerModelMapper())
        {
            
        }

        public FmContext(IPlayerModelMapper playerMapper)
        {
            _playerMapper = playerMapper;
        }

        public List<PlayerModel> Players
        {
            get
            {
                return _playerModels ?? (_playerModels = GetPlayerModels());
            }
        }

        private List<PlayerModel> GetPlayerModels()
        {
            EnsureGameLoaded();
            return MainProcess.Persons
                .Where(p => p.Type == PersonType.Player)
                .Select(Player.FromPerson)
                .Select(_playerMapper.Map)
                .ToList();
        }

        private void EnsureGameLoaded()
        {
            if (_isGameLoaded)
                return;

            LoadGame();
        }

        private void LoadGame()
        {
            MainProcess.LoadGame(new ProgressBar());
            _isGameLoaded = true;
        }
    }
}
