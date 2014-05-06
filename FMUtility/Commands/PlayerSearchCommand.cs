using System;
using System.ComponentModel;
using System.Windows.Input;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;
using FMUtility.ViewModels;

namespace FMUtility.Commands
{
    public class PlayerSearchCommand : ICommand
    {
        private readonly IEventBus _eventBus;
        private readonly IPlayerSearchViewModel _playerSearchViewModel;

        public PlayerSearchCommand(IPlayerSearchViewModel viewModel)
            : this(viewModel, EventBus.Instance)
        {

        }

        public PlayerSearchCommand(IPlayerSearchViewModel playerSearchViewModel, IEventBus eventBus)
        {
            _playerSearchViewModel = playerSearchViewModel;
            _eventBus = eventBus;
            PropertyChangedEventManager.AddHandler(_playerSearchViewModel, HandlePropertyChanged, string.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _playerSearchViewModel.HasCriteria;
        }

        public void Execute(object parameter)
        {
            _eventBus.Publish(new PlayerSearchArgs());
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
