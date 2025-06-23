using System.Threading.Tasks;

namespace EventTriggerLibrary.Interfaces
{
    public interface IConsumer<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event);
    }
}
