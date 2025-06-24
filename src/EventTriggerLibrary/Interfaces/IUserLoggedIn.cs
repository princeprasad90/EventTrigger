using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Interfaces
{
    /// <summary>
    /// Marker interface for user login events across modules.
    /// Provides the username of the logged-in user.
    /// </summary>
    public interface IUserLoggedIn : IEvent
    {
        string Username { get; }
    }
}
