using System;
using System.Windows.Input;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;
using FMUtility.Models;

namespace FMUtility.Commands
{
    public class ViewPlayerCommand : ICommand
    {
        private readonly IEventBus _eventBus;

        public ViewPlayerCommand() : this(EventBus.Instance)
        {
            
        }

        public ViewPlayerCommand(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public bool CanExecute(object parameter)
        {
            return (parameter as PlayerModel) != null;;
        }

        public void Execute(object parameter)
        {
            var playerModel = parameter as PlayerModel;
            if (playerModel == null)
                return;

            var args = new ViewPlayerArgs(playerModel.Id);
            _eventBus.Publish(args);
        }

        public event EventHandler CanExecuteChanged;
    }
}
