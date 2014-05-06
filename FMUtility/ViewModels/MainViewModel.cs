using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;

namespace FMUtility.ViewModels
{
    public class MainViewModel: ViewModelBase, IHandler<CloseDocumentArgs>
    {
        private readonly ObservableCollection<IDocumentViewModel> _documents;
        private readonly ObservableCollection<IDocumentViewModel> _anchoredDocuments; 

        public ObservableCollection<IDocumentViewModel> Documents
        {
            get { return _documents; }
        }

        public ObservableCollection<IDocumentViewModel> AnchoredDocuments
        {
            get { return _anchoredDocuments; }
        }

        public MainViewModel() : this(EventBus.Instance, new PlayerSearchViewModel())
        {
            
        }

        public MainViewModel(IEventBus eventBus, IPlayerSearchViewModel playerSearchViewModel)
        {
            _documents = new ObservableCollection<IDocumentViewModel>();
            _anchoredDocuments = new ObservableCollection<IDocumentViewModel>
            {
                playerSearchViewModel
            };

            eventBus.Subscribe(this);
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
