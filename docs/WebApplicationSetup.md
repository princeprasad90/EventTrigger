# Using EventTriggerLibrary in an ASP.NET Web Application

This guide describes how to integrate the `EventTriggerLibrary` into an ASP.NET web application using the Unity container.

## Setup

1. **Reference the library**
   Ensure your web project references `EventTriggerLibrary.dll` and `Unity`.

2. **Configure Unity**
   Create a Unity container during application startup (e.g., in `Global.asax` or an OWIN startup class) and register the services:

   ```csharp
   var container = new UnityContainer();
   container.RegisterType<IEventPublisher, EventPublisher>(TypeLifetime.Singleton);
   container.RegisterType<IAuthService, AuthService>(TypeLifetime.Singleton);
   
   // Automatically register all IConsumer<TEvent> implementations
   container.RegisterEventConsumers(typeof(AuthService).Assembly);
   ```

   The `RegisterEventConsumers` extension scans the specified assemblies and registers every implementation of `IConsumer<T>` using its full type name so that multiple consumers can exist for the same event.

3. **Resolve services**
   Use the container to resolve `IAuthService`, `IEventPublisher`, or any custom consumer wherever needed in your application (e.g., in controllers or other services).

4. **Publish events**
   Invoke `IEventPublisher.PublishAsync` to trigger events. All registered consumers will be executed.

## Example

Below is a minimal example of initializing Unity in `Global.asax`:

```csharp
protected void Application_Start()
{
    var container = new UnityContainer();
    container.RegisterType<IEventPublisher, EventPublisher>(TypeLifetime.Singleton);
    container.RegisterType<IAuthService, AuthService>(TypeLifetime.Singleton);
    
    // Register consumers found in this project
    container.RegisterEventConsumers(typeof(MvcApplication).Assembly);

    // store container for later use (e.g., DependencyResolver)
}
```

Refer to `UnityExtensions.RegisterEventConsumers` in the library for details.
