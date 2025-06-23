using System;
using System.Threading.Tasks;
using EventTriggerLibrary.Events;
using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Services
{
    public class EventConsumer1 :
        IConsumer<UserLoginSuccess>,
        IConsumer<UserLoginFailure>
    {
        public Task HandleAsync(UserLoginSuccess @event)
        {
            Console.WriteLine($"[Consumer1] Login succeeded for {@event.Username}");
            return Task.CompletedTask;
        }

        public Task HandleAsync(UserLoginFailure @event)
        {
            Console.WriteLine($"[Consumer1] Login failed for {@event.Username}: {@event.Reason}");
            return Task.CompletedTask;
        }
    }
}
