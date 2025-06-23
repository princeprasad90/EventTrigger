using System;
using System.Threading.Tasks;
using EventTriggerLibrary.Interfaces;
using Unity;

namespace EventTriggerLibrary.Services
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IUnityContainer _container;

        public EventPublisher(IUnityContainer container)
        {
            _container = container;
        }

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handlers = _container.ResolveAll<IConsumer<TEvent>>();
            foreach (var handler in handlers)
            {
                await handler.HandleAsync(@event);
            }
        }
    }

    public interface IEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
