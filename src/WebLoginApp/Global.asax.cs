using System.Web.Mvc;
using System.Web.Routing;
using EventTriggerLibrary.Extensions;
using EventTriggerLibrary.Services;
using Unity;
using Unity.Mvc5;

namespace WebLoginApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IUnityContainer Container { get; private set; }

        protected void Application_Start()
        {
            Container = new UnityContainer();
            Container.RegisterType<IEventPublisher, EventPublisher>(TypeLifetime.Singleton);
            Container.RegisterType<IAuthService, AuthService>(TypeLifetime.Singleton);

            // automatically register consumers in this assembly
            Container.RegisterEventConsumers(typeof(MvcApplication).Assembly);

            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
