using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Events
{
    public class UserLoginFailure : IEvent
    {
        public string Username { get; }
        public string Reason { get; }

        public UserLoginFailure(string username, string reason)
        {
            Username = username;
            Reason = reason;
        }
    }
}
