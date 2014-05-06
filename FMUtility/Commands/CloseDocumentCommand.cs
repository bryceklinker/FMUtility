using System;
using System.ComponentModel;
using System.Windows.Input;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;
using FMUtility.ViewModels;

namespace FMUtility.Commands
{
    public class CloseDocumentCommand : ICommand
    {
        private readonly IEventBus _eventBus;
        private readonly IDocumentViewModel _documentViewModel;

        public CloseDocumentCommand(IDocumentViewModel documentViewModel) : this(EventBus.Instance, documentViewModel)
        {
            
        }

        public CloseDocumentCommand(IEventBus eventBus, IDocumentViewModel documentViewModel)
        {
            _eventBus = eventBus;
            _documentViewModel = documentViewModel;
            PropertyChangedEventManager.AddHandler(_documentViewModel, HandlePropertyChanged, string.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _documentViewModel.CanClose;
        }

        public void Execute(object parameter)
        {
            _eventBus.Publish(new CloseDocumentArgs(_documentViewModel.Id));
        }

        public event EventHandler CanExecuteChanged;

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            RaiseCanExecuteChanged();
        }

        private void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null) 
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
