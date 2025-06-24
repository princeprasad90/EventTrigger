using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Interfaces
{
    /// <summary>
    /// Marker interface for user registration events across modules.
    /// Provides the username of the registered user.
    /// </summary>
    public interface IUserRegistered : IEvent
    {
        string Username { get; }
    }
}
