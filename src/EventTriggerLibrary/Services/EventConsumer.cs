using System;
using System.Threading.Tasks;
using EventTriggerLibrary.Events;
using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Services
{
    public class EventConsumer :
        IConsumer<UserLoginSuccess>,
        IConsumer<UserLoginFailure>,
        IConsumer<StandardUserRegistered>,
        IConsumer<StandardUserLoggedIn>,
        IConsumer<GoldUserRegistered>,
        IConsumer<GoldUserLoggedIn>,
        IConsumer<DiamondUserRegistered>,
        IConsumer<DiamondUserLoggedIn>
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

        public Task HandleAsync(StandardUserRegistered @event)
        {
            Console.WriteLine($"Standard user registered: {@event.Username}");
            return Task.CompletedTask;
        }

        public Task HandleAsync(StandardUserLoggedIn @event)
        {
            Console.WriteLine($"Standard user logged in: {@event.Username}");
            return Task.CompletedTask;
        }

        public Task HandleAsync(GoldUserRegistered @event)
        {
            Console.WriteLine($"Gold user registered: {@event.Username}");
            return Task.CompletedTask;
        }

        public Task HandleAsync(GoldUserLoggedIn @event)
        {
            Console.WriteLine($"Gold user logged in: {@event.Username}");
            return Task.CompletedTask;
        }

        public Task HandleAsync(DiamondUserRegistered @event)
        {
            Console.WriteLine($"Diamond user registered: {@event.Username}");
            return Task.CompletedTask;
        }

        public Task HandleAsync(DiamondUserLoggedIn @event)
        {
            Console.WriteLine($"Diamond user logged in: {@event.Username}");
            return Task.CompletedTask;
        }
    }
}
