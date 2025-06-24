using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Events
{
    /// <summary>
    /// Event published when a gold user registers.
    /// </summary>
    public class GoldUserRegistered : EventBase, IUserRegistered
    {
        public string Username { get; }

        public GoldUserRegistered(string username)
        {
            Username = username;
        }
    }
}
