using System;
using System.Threading.Tasks;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;

namespace FMUtility.Threading
{
    public interface ITaskFactory
    {
        Task<T> StartNew<T>(Func<T> func, string statusText = "Loading...");
    }

    public class TaskFactory : ITaskFactory
    {
        private readonly IEventBus _eventBus;
        private static TaskFactory _instance;
        private readonly System.Threading.Tasks.TaskFactory _taskFactory;

        public static ITaskFactory Instance
        {
            get { return _instance ?? (_instance = new TaskFactory()); }
        }

        private TaskFactory() : this(EventBus.Instance)
        {

        }

        private TaskFactory(IEventBus eventBus)
        {
            _eventBus = eventBus;
            _taskFactory = new System.Threading.Tasks.TaskFactory();
        }

        public Task<T> StartNew<T>(Func<T> func, string statusText = "Loading...")
        {
            PublishStatus(true, statusText);
            var task = _taskFactory.StartNew(func);
            task.ContinueWith(t => PublishStatus(false, null));
            return task;
        }

        private void PublishStatus(bool isBusy, string statusText)
        {
            var args = new StatusArgs
            {
                IsBusy = isBusy,
                Text = statusText
            };
            _eventBus.Publish(args);
        }
    }
}
