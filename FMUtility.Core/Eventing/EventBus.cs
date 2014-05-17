using System.Collections.Generic;
using System.Linq;

namespace FMUtility.Core.Eventing
{
    public interface IHandle<T>
    {
        void Handle(T args);
    }

    public interface IEventBus
    {
        void Subscribe<T>(IHandle<T> handle);
        void Publish<T>(T args);
    }

    public class EventBus : IEventBus
    {
        private static EventBus _instance;
        private readonly Dictionary<int, List<object>> _subscribers;

        public EventBus()
        {
            _subscribers = new Dictionary<int, List<object>>();
        }

        public static EventBus Instance
        {
            get { return _instance ?? (_instance = new EventBus()); }
        }

        public void Subscribe<T>(IHandle<T> handle)
        {
            var subscribers = GetSubscribers<T>();
            subscribers.Add(handle);
        }

        public void Publish<T>(T args)
        {
            var subscribers = GetSubscribers<T>().Cast<IHandle<T>>();
            foreach (var subscriber in subscribers)
                subscriber.Handle(args);
        }

        private List<object> GetSubscribers<T>()
        {
            var typeHash = typeof (T).GetHashCode();
            List<object> subscribers;
            if (_subscribers.ContainsKey(typeHash))
            {
                subscribers = _subscribers[typeHash];
            }
            else
            {
                subscribers = new List<object>();
                _subscribers.Add(typeHash, subscribers);
            }
            return subscribers;
        }
    }
}