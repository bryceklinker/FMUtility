using System;
using System.Windows.Input;

namespace FMUtility.ViewModels
{
    public interface ISearchViewModel : IDocumentViewModel
    {

    }

    public class SearchViewModel : ViewModelBase, ISearchViewModel
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public ICommand Close { get; private set; }
    }
}
