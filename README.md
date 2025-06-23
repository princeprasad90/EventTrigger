# EventTrigger Example

This repository contains a simple example of triggering and consuming events when a user logs in. It targets **.NET Framework 4.8** and uses **Unity** for dependency injection.

## Projects

- `EventTriggerLibrary` &ndash; class library that defines event interfaces, concrete events, and services for publishing and handling events.
- `LoginConsole` &ndash; minimal console application demonstrating the login flow and event handling.

## Usage

This solution is designed for Visual Studio. Restore NuGet packages and run the `LoginConsole` project. When a user logs in successfully or fails, the corresponding event is published and handled by `EventConsumer`.

```bash
\# Restore packages
nuget restore

\# Build the solution (e.g., using MSBuild or Visual Studio)
msbuild EventTrigger.sln
```

Run the console application and enter credentials. The password `password` is considered valid.

### Dynamic consumer registration

Consumers can be loaded from additional assemblies by setting the `CONSUMER_ASSEMBLIES` environment variable before running the console application. Provide a semicolon-separated list of assembly names:

```bash
export CONSUMER_ASSEMBLIES="MyPlugin.dll;OtherConsumers.dll"
```

If the variable is not set, the `LoginConsole` project registers the consumers contained in the sample library.

### Multiple consumers

`Unity` is configured to resolve all registered implementations of `IConsumer<TEvent>`.
To handle an event with multiple consumers, register each consumer with a unique
name. `EventConsumer` and `EventConsumer1` in this sample both handle login
events and will be invoked for the same published event.

### Automatic consumer registration

The library exposes an extension method `RegisterEventConsumers` that scans an
assembly for all `IConsumer<TEvent>` implementations and registers them using
their type names. The `LoginConsole` project calls:

```csharp
container.RegisterEventConsumers(typeof(EventConsumer).Assembly);
```

This eliminates the need to manually register each event/consumer pair.

### Event metadata

All events inherit from `EventBase`, which records the time the event was created. Consumers can use this timestamp for logging or ordering purposes.

### Parallel event handling

`EventPublisher` now invokes consumers concurrently and logs any exceptions so one failing handler does not block others.

### ASP.NET integration

For guidance on configuring Unity and automatic consumer registration in an ASP.NET web application, see [docs/WebApplicationSetup.md](docs/WebApplicationSetup.md).
