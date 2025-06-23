using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Events
{
    public class UserLoginSuccess : IEvent
    {
        public string Username { get; }

        public UserLoginSuccess(string username)
        {
            Username = username;
        }
    }
}
