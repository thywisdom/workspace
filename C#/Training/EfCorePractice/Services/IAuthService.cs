using System.Threading.Tasks;
using EfCorePractice.Models;

namespace EfCorePractice.Services;

public interface IAuthService
{
    Task<(string AccessToken, string RefreshToken)?> AuthenticateAsync(string username, string password);
    Task<(string AccessToken, string RefreshToken)?> RefreshTokenAsync(string refreshToken);
    Task<bool> RevokeRefreshTokenAsync(string username);
    Task<User?> GetUserAsync(string username);
    Task<User> RegisterUserAsync(string username, string password, string[] roles);
}
