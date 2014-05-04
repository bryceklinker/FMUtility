using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace FMUtility.Eventing
{
    public interface IHandler<T>
    {
        void Handle(T args);
    }

    public interface IEventBus
    {
        void Subscribe<T>(IHandler<T> handler);
        void Publish<T>(T args);
    }

    public class EventBus : IEventBus
    {
        private static EventBus _instance;
        private readonly Dictionary<int, List<object>> _subscribers; 

        public static EventBus Instance
        {
            get { return _instance ?? (_instance = new EventBus()); }
        }

        public EventBus()
        {
            _subscribers = new Dictionary<int, List<object>>();
        }

        public void Subscribe<T>(IHandler<T> handler)
        {
            var subscribers = GetSubscribers<T>();
            subscribers.Add(handler);
        }

        public void Publish<T>(T args)
        {
            var subscribers = GetSubscribers<T>().Cast<IHandler<T>>();
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
