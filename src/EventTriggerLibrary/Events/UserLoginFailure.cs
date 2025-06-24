using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Events
{
    /// <summary>
    /// Event published when a user login attempt fails.
    /// </summary>
    public class UserLoginFailure : EventBase, IHasUserType
    {
        public string Username { get; }
        public string Reason { get; }
        public IUserType UserType { get; }

        public UserLoginFailure(string username, string reason, IUserType userType)
        {
            Username = username;
            Reason = reason;
            UserType = userType;
        }
    }
}
