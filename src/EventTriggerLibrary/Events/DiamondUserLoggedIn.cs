using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Events
{
    /// <summary>
    /// Event published when a diamond user logs in.
    /// </summary>
    public class DiamondUserLoggedIn : EventBase
    {
        public string Username { get; }

        public DiamondUserLoggedIn(string username)
        {
            Username = username;
        }
    }
}
