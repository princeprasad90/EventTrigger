using System;
using System.Threading.Tasks;
using EventTriggerLibrary.Events;
using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Services
{
    public class EventConsumer :
        IConsumer<UserLoginSuccess>,
        IConsumer<UserLoginFailure>,
        IConsumer<IUserRegistered>,
        IConsumer<IUserLoggedIn>
    {
        public Task HandleAsync(UserLoginSuccess @event)
        {
            Console.WriteLine($"Login succeeded for {@event.Username} ({@event.UserType.Name})");
            return Task.CompletedTask;
        }

        public Task HandleAsync(UserLoginFailure @event)
        {
            Console.WriteLine($"Login failed for {@event.Username} ({@event.UserType.Name}): {@event.Reason}");
            return Task.CompletedTask;
        }

        public Task HandleAsync(IUserRegistered @event)
        {
            Console.WriteLine($"User registered: {@event.Username} (event: {@event.GetType().Name})");
            return Task.CompletedTask;
        }

        public Task HandleAsync(IUserLoggedIn @event)
        {
            Console.WriteLine($"User logged in: {@event.Username} (event: {@event.GetType().Name})");
            return Task.CompletedTask;
        }
    }
}
