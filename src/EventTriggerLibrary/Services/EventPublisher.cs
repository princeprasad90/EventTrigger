using System;
using System.Collections.Generic;
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
            if (@event is IHasUserType typedEvent)
            {
                // Demonstrate that the publisher can access the user type via the interface
                Console.WriteLine($"Publishing {@event.GetType().Name} for user type {typedEvent.UserType.Name}");
            }

            var handlers = _container.ResolveAll<IConsumer<TEvent>>();

            var tasks = new List<Task>();
            foreach (var handler in handlers)
            {
                tasks.Add(InvokeHandlerAsync(handler, @event));
            }

            await Task.WhenAll(tasks);
        }

        private static async Task InvokeHandlerAsync<TEvent>(IConsumer<TEvent> handler, TEvent @event) where TEvent : IEvent
        {
            try
            {
                await handler.HandleAsync(@event);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling {@event.GetType().Name} in {handler.GetType().Name}: {ex.Message}");
            }
        }
    }

    public interface IEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
