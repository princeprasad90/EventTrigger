using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Events
{
    /// <summary>
    /// Event published when a standard user logs in.
    /// </summary>
    public class StandardUserLoggedIn : EventBase
    {
        public string Username { get; }

        public StandardUserLoggedIn(string username)
        {
            Username = username;
        }
    }
}
