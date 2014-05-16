using System.Collections.ObjectModel;
using System.Windows.Input;
using FMUtility.Commands;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;
using FMUtility.Data;
using FMUtility.Data.Queries;
using FMUtility.Models;

namespace FMUtility.ViewModels
{
    public interface IClubSearchViewModel : IDocumentViewModel
    {
        string Name { get; set; }
        int? Reputation { get; set; }
        bool HasCriteria { get; }
    }

    public class ClubSearchViewModel : DocumentViewModel, IClubSearchViewModel, IHandler<ClubSearchArgs>
    {
        private readonly IClubGateway _clubGateway;
        private readonly ObservableCollection<ClubModel> _clubs;
        private readonly ClubSearchCommand _search;
        private string _name;
        private int? _reputation;

        public override string Title
        {
            get { return "Club Search"; }
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

        public int? Reputation
        {
            get { return _reputation; }
            set
            {
                _reputation = value;
                RaisePropertyChanged(() => Reputation);
            }
        }

        public bool HasCriteria
        {
            get { return !string.IsNullOrWhiteSpace(Name) || Reputation.HasValue; }
        }

        public ObservableCollection<ClubModel> Clubs
        {
            get { return _clubs; }
        }

        public ClubSearchViewModel() : this(new ClubGateway())
        {
            
        }

        public ClubSearchViewModel(IClubGateway clubGateway) : base(false)
        {
            _clubGateway = clubGateway;
            _search = new ClubSearchCommand(this);
            _clubs = new ObservableCollection<ClubModel>();
        }

        public async void Handle(ClubSearchArgs args)
        {
            Clubs.Clear();
            var query = new ClubSearchQuery(args);
            var clubs = await _clubGateway.Get(query).ConfigureAwait(true);
            foreach (var club in clubs)
                Clubs.Add(club);
        }
    }
}
