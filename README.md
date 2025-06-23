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

### Multiple consumers

`Unity` is configured to resolve all registered implementations of `IConsumer<TEvent>`.
To handle an event with multiple consumers, register each consumer with a unique
name. `EventConsumer` and `EventConsumer1` in this sample both handle login
events and will be invoked for the same published event.
