using System.Threading.Tasks;
using EventTriggerLibrary.Events;
using EventTriggerLibrary.Interfaces;
using EventTriggerLibrary.Types;
using System;

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
            var userType = DetermineUserType(username);
            if (password == "password")
            {
                await _publisher.PublishAsync(new UserLoginSuccess(username, userType));
                return true;
            }
            await _publisher.PublishAsync(new UserLoginFailure(username, "Invalid password", userType));
            return false;
        }

        private static IUserType DetermineUserType(string username)
        {
            if (username?.StartsWith("diamond", StringComparison.OrdinalIgnoreCase) == true)
            {
                return new DiamondUserType();
            }
            if (username?.StartsWith("gold", StringComparison.OrdinalIgnoreCase) == true)
            {
                return new GoldUserType();
            }
            return new StandardUserType();
        }
    }
}
