using System;
using System.Linq;
using System.Reflection;
using Unity;
using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Extensions
{
    public static class UnityExtensions
    {
        /// <summary>
        /// Registers all implementations of <see cref="IConsumer{T}"/> found in the
        /// provided assemblies. Each registration uses the consumer type's full
        /// name as the registration name so multiple consumers for the same
        /// event can coexist.
        /// </summary>
        /// <param name="container">Unity container.</param>
        /// <param name="assemblies">Assemblies to scan. If empty, the calling
        /// assembly is scanned.</param>
        public static void RegisterEventConsumers(this IUnityContainer container,
            params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Length == 0)
            {
                assemblies = new[] { Assembly.GetCallingAssembly() };
            }

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes()
                    .Where(t => !t.IsAbstract && !t.IsInterface)
                    .ToList();

                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces()
                        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConsumer<>));

                    foreach (var iface in interfaces)
                    {
                        container.RegisterType(iface, type, type.FullName);
                    }
                }
            }
        }
    }
}
