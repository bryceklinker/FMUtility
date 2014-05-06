namespace FMUtility.ViewModels
{
    public interface ISearchViewModel : IDocumentViewModel
    {

    }

    public class SearchViewModel : DocumentViewModel, ISearchViewModel
    {
        public override string Title
        {
            get { return "Search"; }
        }

        public SearchViewModel() : base(false)
        {
            
        }
    }
}
