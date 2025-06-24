using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Events
{
    /// <summary>
    /// Event published when a user successfully logs in.
    /// Inherits from <see cref="EventBase"/> to provide a timestamp.
    /// </summary>
    public class UserLoginSuccess : EventBase, IHasUserType
    {
        public string Username { get; }
        public IUserType UserType { get; }

        public UserLoginSuccess(string username, IUserType userType)
        {
            Username = username;
            UserType = userType;
        }
    }
}
