using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Events
{
    /// <summary>
    /// Event published when a user login attempt fails.
    /// </summary>
    public class UserLoginFailure : EventBase
    {
        public string Username { get; }
        public string Reason { get; }
        public UserType UserType { get; }

        public UserLoginFailure(string username, string reason, UserType userType)
        {
            Username = username;
            Reason = reason;
            UserType = userType;
        }
    }
}
