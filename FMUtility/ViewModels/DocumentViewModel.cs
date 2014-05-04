using System;
using System.ComponentModel;
using System.Windows.Input;

namespace FMUtility.ViewModels
{
    public interface IDocumentViewModel : INotifyPropertyChanged
    {
        Guid Id { get;}
        string Title { get;}
        ICommand Close { get; }
    }
}
