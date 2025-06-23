using System.Threading.Tasks;
using EventTriggerLibrary.Events;
using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string username, string password);
    }

    public class AuthService : IAuthService
    {
        private readonly IEventPublisher _publisher;

        public AuthService(IEventPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            // simple demo logic: password must equal "password"
            if (password == "password")
            {
                await _publisher.PublishAsync(new UserLoginSuccess(username));
                return true;
            }
            await _publisher.PublishAsync(new UserLoginFailure(username, "Invalid password"));
            return false;
        }
    }
}
