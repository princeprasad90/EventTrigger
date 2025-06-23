using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Events
{
    /// <summary>
    /// Event published when a user successfully logs in.
    /// Inherits from <see cref="EventBase"/> to provide a timestamp.
    /// </summary>
    public class UserLoginSuccess : EventBase
    {
        public string Username { get; }

        public UserLoginSuccess(string username)
        {
            Username = username;
        }
    }
}
