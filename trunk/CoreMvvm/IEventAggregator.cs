using System;
using System.Threading.Tasks;

namespace CoreMvvm
{
    public interface IEventAggregator 
    {
        Task Publish<TEvent>(TEvent @event);
        void Subscribe<TEvent>(Func<TEvent, Task> handler);
    }
}