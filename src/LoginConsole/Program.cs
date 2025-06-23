using System;
using System.Threading.Tasks;
using EventTriggerLibrary.Services;
using EventTriggerLibrary.Interfaces;
using Unity;

namespace LoginConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<IEventPublisher, EventPublisher>(TypeLifetime.Singleton);
            container.RegisterType<IAuthService, AuthService>(TypeLifetime.Singleton);
            container.RegisterType<IConsumer<EventTriggerLibrary.Events.UserLoginSuccess>, EventConsumer>("consumerA");
            container.RegisterType<IConsumer<EventTriggerLibrary.Events.UserLoginSuccess>, EventConsumer1>("consumerB");
            container.RegisterType<IConsumer<EventTriggerLibrary.Events.UserLoginFailure>, EventConsumer>("consumerA");
            container.RegisterType<IConsumer<EventTriggerLibrary.Events.UserLoginFailure>, EventConsumer1>("consumerB");

            var authService = container.Resolve<IAuthService>();

            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            var result = await authService.LoginAsync(username, password);
            Console.WriteLine($"Login result: {result}");
        }
    }
}
