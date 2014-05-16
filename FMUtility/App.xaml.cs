using System;
using System.Windows;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;

namespace FMUtility
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IEventBus _eventBus;

        public App() : this(EventBus.Instance)
        {
        }

        public App(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandleExceptions;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            AppDomain.CurrentDomain.UnhandledException -= HandleUnhandleExceptions;
        }

        private void HandleUnhandleExceptions(object sender, UnhandledExceptionEventArgs e)
        {
            var args = new StatusArgs
            {
                IsBusy = false,
                Text = ((Exception) e.ExceptionObject).Message
            };
            _eventBus.Publish(args);
        }
    }
}