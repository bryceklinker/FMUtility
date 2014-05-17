using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FMEditorLive.FMObjects;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;
using FMUtility.Data.Mappers;
using FMUtility.Models;

namespace FMUtility.Data
{
    public interface IFmContext
    {
        List<PlayerModel> Players { get; }
        List<ClubModel> Clubs { get; }
    }

    public class FmContext : IFmContext
    {
        private static IFmContext _instance;
        private readonly IEventBus _eventBus;
        private readonly IPlayerModelMapper _playerMapper;
        private readonly IClubModelMapper _clubMapper;
        private bool _isGameLoaded;
        private List<PlayerModel> _playerModels;
        private List<ClubModel> _clubModels; 

        private FmContext()
            : this(new PlayerModelMapper(), new ClubModelMapper(), EventBus.Instance)
        {
        }

        private FmContext(IPlayerModelMapper playerMapper, IClubModelMapper clubMapper, IEventBus eventBus)
        {
            _playerMapper = playerMapper;
            _clubMapper = clubMapper;
            _eventBus = eventBus;
        }

        public static IFmContext Instance
        {
            get { return _instance ?? (_instance = new FmContext()); }
            set { _instance = value; }
        }

        public List<PlayerModel> Players
        {
            get { return _playerModels ?? (_playerModels = GetPlayerModels()); }
        }

        public List<ClubModel> Clubs
        {
            get { return _clubModels ?? (_clubModels = GetClubModels()); }
        }

        private List<ClubModel> GetClubModels()
        {
            EnsureGameLoaded();
            PublishStatus("Loading clubs in game...");
            return MainProcess.Clubs.Select(_clubMapper.Map).ToList();
        }

        private List<PlayerModel> GetPlayerModels()
        {
            EnsureGameLoaded();
            PublishStatus("Loading players in game...");
            return MainProcess.Persons
                .Where(p => p.Type == PersonType.Player)
                .Select(Player.FromPerson)
                .Select(_playerMapper.Map).ToList();
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