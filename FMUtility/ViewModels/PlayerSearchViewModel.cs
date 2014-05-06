using System.Windows.Input;
using FMUtility.Commands;

namespace FMUtility.ViewModels
{
    public interface IPlayerSearchViewModel : IDocumentViewModel
    {
        bool HasCriteria { get; }
    }

    public class PlayerSearchViewModel : DocumentViewModel, IPlayerSearchViewModel
    {
        private readonly PlayerSearchCommand _search;
        private string _name;
        private int? _currentAbility;
        private int? _potentialAbility;

        public override string Title
        {
            get { return "Player Search"; }
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

        public PlayerSearchViewModel() : base(false)
        {
            _search = new PlayerSearchCommand(this);
        }
    }
}
