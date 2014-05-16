using System;
using System.ComponentModel;
using System.Windows.Input;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;
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
            var args = new PlayerSearchArgs
            {
                CurrentAbility = _playerSearchViewModel.CurrentAbility,
                Name = _playerSearchViewModel.Name,
                PotentialAbility = _playerSearchViewModel.PotentialAbility
            };
            _eventBus.Publish(args);
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