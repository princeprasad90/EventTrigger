using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Events
{
    /// <summary>
    /// Event published when a diamond user registers.
    /// </summary>
    public class DiamondUserRegistered : EventBase, IUserRegistered
    {
        public string Username { get; }

        public DiamondUserRegistered(string username)
        {
            Username = username;
        }
    }
}
