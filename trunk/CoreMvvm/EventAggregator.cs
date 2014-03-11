using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreMvvm
{
    // todo: add Unsubscribe method
    public class EventAggregator : IEventAggregator
    {
        private readonly IDictionary<Type, IList<Func<object, Task>>> _handlingActionsByEventType = new Dictionary<Type, IList<Func<object, Task>>>();

        public async Task Publish<TEvent>(TEvent @event)
        {
            var type = typeof (TEvent);
            if (!_handlingActionsByEventType.ContainsKey(type)) return;
            var handlers = _handlingActionsByEventType[type];
            foreach (var handler in handlers)
            {
                await handler(@event);
            }
        }

        public void Subscribe<TEvent>(Func<TEvent, Task> handler)
        {
            var type = typeof (TEvent);
            if (!_handlingActionsByEventType.ContainsKey(type))
            {
                _handlingActionsByEventType.Add(type, new List<Func<object, Task>>());
            }
            _handlingActionsByEventType[type].Add(async x => await handler((TEvent)x));
        }
    }
}