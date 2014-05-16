using System.Collections.ObjectModel;
using System.Linq;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;

namespace FMUtility.ViewModels
{
    public class MainViewModel : ViewModelBase, IHandler<CloseDocumentArgs>, IHandler<ViewPlayerArgs>
    {
        private readonly ObservableCollection<IDocumentViewModel> _anchoredDocuments;
        private readonly ObservableCollection<IDocumentViewModel> _documents;

        public MainViewModel() : this(EventBus.Instance, new PlayerSearchViewModel(), new ClubSearchViewModel())
        {
        }

        public MainViewModel(IEventBus eventBus, IPlayerSearchViewModel playerSearchViewModel, IClubSearchViewModel clubSearchViewModel)
        {
            _documents = new ObservableCollection<IDocumentViewModel>();
            _anchoredDocuments = new ObservableCollection<IDocumentViewModel>
            {
                playerSearchViewModel,
                clubSearchViewModel
            };

            eventBus.Subscribe<CloseDocumentArgs>(this);
            eventBus.Subscribe<ViewPlayerArgs>(this);
        }

        public ObservableCollection<IDocumentViewModel> Documents
        {
            get { return _documents; }
        }

        public ObservableCollection<IDocumentViewModel> AnchoredDocuments
        {
            get { return _anchoredDocuments; }
        }

        public void Handle(CloseDocumentArgs args)
        {
            IDocumentViewModel matchingDocument = Documents.SingleOrDefault(d => d.Id == args.DocumentId);
            if (matchingDocument == null)
                return;
            Documents.Remove(matchingDocument);
        }

        public void Handle(ViewPlayerArgs args)
        {
            var document = new PlayerViewModel(args.PlayerId);
            Documents.Add(document);
        }
    }
}