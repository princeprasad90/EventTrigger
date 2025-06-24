using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Events
{
    /// <summary>
    /// Event published when a gold user logs in.
    /// </summary>
    public class GoldUserLoggedIn : EventBase
    {
        public string Username { get; }

        public GoldUserLoggedIn(string username)
        {
            Username = username;
        }
    }
}
