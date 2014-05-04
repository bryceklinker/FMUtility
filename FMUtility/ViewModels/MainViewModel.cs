using System.Collections.ObjectModel;
using System.Linq;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;

namespace FMUtility.ViewModels
{
    public class MainViewModel: ViewModelBase, IHandler<CloseDocumentArgs>
    {
        private readonly IEventBus _eventBus;
        private readonly ObservableCollection<IDocumentViewModel> _documents;

        public ObservableCollection<IDocumentViewModel> Documents
        {
            get { return _documents; }
        }

        public MainViewModel() : this(EventBus.Instance, new SearchViewModel())
        {
            
        }

        public MainViewModel(IEventBus eventBus, ISearchViewModel searchViewModel)
        {
            _documents = new ObservableCollection<IDocumentViewModel>
            {
                searchViewModel   
            };

            _eventBus = eventBus;
            _eventBus.Subscribe(this);
        }

        public void Handle(CloseDocumentArgs args)
        {
            var matchingDocument = Documents.SingleOrDefault(d => d.Id == args.DocumentId);
            if (matchingDocument == null)
                return;
            Documents.Remove(matchingDocument);
        }
    }
}
