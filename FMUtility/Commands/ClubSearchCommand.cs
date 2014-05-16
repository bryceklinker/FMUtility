using System;
using System.ComponentModel;
using System.Windows.Input;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;
using FMUtility.ViewModels;

namespace FMUtility.Commands
{
    public class ClubSearchCommand : ICommand
    {
        private readonly IClubSearchViewModel _clubSearchViewModel;
        private readonly IEventBus _eventBus;

        public ClubSearchCommand(IClubSearchViewModel clubSearchViewModel) : this(clubSearchViewModel, EventBus.Instance)
        {
            
        }

        public ClubSearchCommand(IClubSearchViewModel clubSearchViewModel, IEventBus eventBus)
        {
            _clubSearchViewModel = clubSearchViewModel;
            _eventBus = eventBus;

            PropertyChangedEventManager.AddHandler(_clubSearchViewModel, HandlePropertyChanged, string.Empty);
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaiseCanExecuteChanged();
        }

        public bool CanExecute(object parameter)
        {
            return _clubSearchViewModel.HasCriteria;
        }

        public void Execute(object parameter)
        {
            var args = new ClubSearchArgs
            {
                Name = _clubSearchViewModel.Name,
                Reputation = _clubSearchViewModel.Reputation
            };
            _eventBus.Publish(args);
        }

        public event EventHandler CanExecuteChanged;

        private void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
