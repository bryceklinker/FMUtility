using System.Collections.ObjectModel;
using System.Windows.Input;
using FMUtility.Commands;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;
using FMUtility.Gateways;
using FMUtility.Models;

namespace FMUtility.ViewModels
{
    public interface IPlayerSearchViewModel : IDocumentViewModel
    {
        bool HasCriteria { get; }
    }

    public class PlayerSearchViewModel : DocumentViewModel, IPlayerSearchViewModel, IHandler<PlayerSearchArgs>
    {
        private readonly IPlayerGateway _gateway;
        private readonly PlayerSearchCommand _search;
        private readonly ViewPlayerCommand _viewPlayer;
        private readonly ObservableCollection<PlayerModel> _players;
        private string _name;
        private int? _currentAbility;
        private int? _potentialAbility;

        public override string Title
        {
            get { return "FirstName Search"; }
        }

        public ICommand Search
        {
            get { return _search; }
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

        public ObservableCollection<PlayerModel> Players
        {
            get { return _players; }
        }

        public ICommand ViewPlayer
        {
            get { return _viewPlayer; }
        }

        public PlayerSearchViewModel() : this(new PlayerGateway())
        {
        }

        public PlayerSearchViewModel(IPlayerGateway gateway) : base(false)
        {
            _gateway = gateway;
            _search = new PlayerSearchCommand(this);
            _viewPlayer = new ViewPlayerCommand();
            _players = new ObservableCollection<PlayerModel>();
        }

        public void Handle(PlayerSearchArgs args)
        {
            _players.Clear();
            var query = new PlayerSearchQuery(args);
            foreach (var player in _gateway.Get(query))
                _players.Add(player);
        }
    }
}
