using System;
using System.Threading.Tasks;
using EventTriggerLibrary.Events;
using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Services
{
    public class EventConsumer :
        IConsumer<UserLoginSuccess>,
        IConsumer<UserLoginFailure>
    {
        public Task HandleAsync(UserLoginSuccess @event)
        {
            Console.WriteLine($"Login succeeded for {@event.Username}");
            return Task.CompletedTask;
        }

        public Task HandleAsync(UserLoginFailure @event)
        {
            Console.WriteLine($"Login failed for {@event.Username}: {@event.Reason}");
            return Task.CompletedTask;
        }
    }
}
