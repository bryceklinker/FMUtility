using System.Collections.ObjectModel;
using System.Windows.Input;
using FMUtility.Commands;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;
using FMUtility.Data;
using FMUtility.Data.Gateways;
using FMUtility.Data.Queries;
using FMUtility.Models;

namespace FMUtility.ViewModels
{
    public interface IPlayerSearchViewModel : IDocumentViewModel
    {
        bool HasCriteria { get; }
        string Name { get; }
        int? CurrentAbility { get; }
        int? PotentialAbility { get; }
    }

    public class PlayerSearchViewModel : DocumentViewModel, IPlayerSearchViewModel, IHandle<PlayerSearchArgs>
    {
        private readonly IPlayerGateway _gateway;
        private readonly ObservableCollection<PlayerModel> _players;
        private readonly PlayerSearchCommand _search;
        private readonly ViewPlayerCommand _viewPlayer;
        private int? _currentAbility;
        private string _name;
        private int? _potentialAbility;

        public PlayerSearchViewModel() : this(EventBus.Instance, new PlayerGateway())
        {
        }

        public PlayerSearchViewModel(IEventBus eventBus, IPlayerGateway gateway) : base(false)
        {
            _gateway = gateway;
            _search = new PlayerSearchCommand(this);
            _viewPlayer = new ViewPlayerCommand();
            _players = new ObservableCollection<PlayerModel>();

            eventBus.Subscribe(this);
        }

        public ICommand Search
        {
            get { return _search; }
        }

        public ObservableCollection<PlayerModel> Players
        {
            get { return _players; }
        }

        public ICommand ViewPlayer
        {
            get { return _viewPlayer; }
        }

        public async void Handle(PlayerSearchArgs args)
        {
            _players.Clear();
            var query = new PlayerSearchQuery(args);
            var players = await _gateway.Get(query).ConfigureAwait(true);
            foreach (var player in players)
                _players.Add(player);
        }

        public override string Title
        {
            get { return "Player Search"; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public int? CurrentAbility
        {
            get { return _currentAbility; }
            set
            {
                _currentAbility = value;
                RaisePropertyChanged(() => CurrentAbility);
            }
        }

        public int? PotentialAbility
        {
            get { return _potentialAbility; }
            set
            {
                _potentialAbility = value;
                RaisePropertyChanged(() => PotentialAbility);
            }
        }

        public bool HasCriteria
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Name)
                       || CurrentAbility.HasValue
                       || PotentialAbility.HasValue;
            }
        }
    }
}