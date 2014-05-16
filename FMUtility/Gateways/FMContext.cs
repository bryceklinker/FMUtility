using System.Collections.Generic;
using System.Linq;
using FMEditorLive.FMObjects;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;
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
        private static IFmContext _instance;
        private readonly IPlayerModelMapper _playerMapper;
        private readonly IEventBus _eventBus;
        private bool _isGameLoaded;
        private List<PlayerModel> _playerModels;

        public static IFmContext Instance
        {
            get { return _instance ?? (_instance = new FmContext()); }
            set { _instance = value; }
        }

        private FmContext()
            : this(new PlayerModelMapper(), EventBus.Instance)
        {

        }

        private FmContext(IPlayerModelMapper playerMapper, IEventBus eventBus)
        {
            _playerMapper = playerMapper;
            _eventBus = eventBus;
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
            PublishStatus("Loading players in game...");
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
            PublishStatus("Loading Game...");
            MainProcess.LoadGame(new ProgressBar());
            _isGameLoaded = true;
        }

        private void PublishStatus(string status)
        {
            var args = new StatusArgs
            {
                IsBusy = true,
                Text = status
            };
            _eventBus.Publish(args);
        }
    }
}
