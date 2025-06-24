using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Events
{
    /// <summary>
    /// Event published when a standard user registers.
    /// </summary>
    public class StandardUserRegistered : EventBase, IUserRegistered
    {
        public string Username { get; }

        public StandardUserRegistered(string username)
        {
            Username = username;
        }
    }
}
