using System;
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

        public CloseDocumentCommand(IDocumentViewModel documentViewModel) : this(EventBus.Instance, documentViewModel)
        {
            
        }

        public CloseDocumentCommand(IEventBus eventBus, IDocumentViewModel documentViewModel, bool canExecute = true)
        {
            _eventBus = eventBus;
            _documentViewModel = documentViewModel;
            _canExecute = canExecute;
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
    }
}
