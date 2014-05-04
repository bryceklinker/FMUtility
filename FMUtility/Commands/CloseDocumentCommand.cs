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
        private readonly bool _canExecute;

        public CloseDocumentCommand(IDocumentViewModel documentViewModel, bool canExecute = true) : this(EventBus.Instance, documentViewModel, canExecute)
        {
            
        }

        public CloseDocumentCommand(IEventBus eventBus, IDocumentViewModel documentViewModel, bool canExecute = true)
        {
            _eventBus = eventBus;
            _documentViewModel = documentViewModel;
            _canExecute = canExecute;
            PropertyChangedEventManager.AddHandler(_documentViewModel, HandlePropertyChanged, string.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
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
