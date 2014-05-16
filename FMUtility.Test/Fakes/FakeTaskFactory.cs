using System;
using System.Threading.Tasks;
using FMUtility.Threading;
using TaskFactory = System.Threading.Tasks.TaskFactory;

namespace FMUtility.Test.Fakes
{
    public class FakeTaskFactory : ITaskFactory
    {
        private readonly TaskFactory _taskFactory;

        public FakeTaskFactory()
        {
            _taskFactory = new TaskFactory();
        }

        public Task<T> StartNew<T>(Func<T> func, string statusText)
        {
            return _taskFactory.StartNew(func);
        }
    }
}
