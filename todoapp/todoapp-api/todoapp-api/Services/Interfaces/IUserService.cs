using Microsoft.AspNetCore.Identity;
using todoapp_api.Models;

namespace todoapp_api.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User>? GetUserByEmailAsync(string email);
        public Task<bool> CheckPasswordAsync(User user, string password);
        public Task<IdentityResult> CreateNewUserAsync(string email, string username, string password);
        public Task<string> GeneratePasswordResetTokenAsync(User user);
        public Task<IdentityResult> ResetPasswordAsync(User user, string resetToken, string newPassword);
        public string GenerateJWTToken(User user);

    }
}
