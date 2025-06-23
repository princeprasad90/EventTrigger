using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EventTriggerLibrary.Services;
using EventTriggerLibrary.Interfaces;
using EventTriggerLibrary.Extensions;
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

            var assemblyNames = Environment.GetEnvironmentVariable("CONSUMER_ASSEMBLIES");
            if (!string.IsNullOrWhiteSpace(assemblyNames))
            {
                var assemblies = assemblyNames
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(Assembly.Load)
                    .ToArray();
                container.RegisterEventConsumers(assemblies);
            }
            else
            {
                container.RegisterEventConsumers(typeof(EventConsumer).Assembly);
            }

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
