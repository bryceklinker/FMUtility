using System;
using System.Windows.Input;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;
using FMUtility.Models;

namespace FMUtility.Commands
{
    public class ViewClubCommand : ICommand
    {
        private readonly IEventBus _eventBus;

        public ViewClubCommand() : this(EventBus.Instance)
        {
            
        }

        public ViewClubCommand(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public bool CanExecute(object parameter)
        {
            return (parameter as ClubModel) != null;
        }

        public void Execute(object parameter)
        {
            var club = parameter as ClubModel;
            if (club == null)
                return;
            var args = new ViewClubArgs
            {
                ClubId = club.Id
            };
            _eventBus.Publish(args);
        }

        public event EventHandler CanExecuteChanged;
    }
}
