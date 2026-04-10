using EfCorePractice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EfCorePractice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var tokens = await _authService.AuthenticateAsync(request.Username, request.Password);
        
        if (tokens == null)
            return Unauthorized("Invalid username or password.");

        return Ok(new
        {
            AccessToken = tokens.Value.AccessToken,
            RefreshToken = tokens.Value.RefreshToken
        });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var existingUser = await _authService.GetUserAsync(request.Username);
        if (existingUser != null)
            return BadRequest("Username already exists.");

        var user = await _authService.RegisterUserAsync(request.Username, request.Password, request.Roles);
        return Ok(new { user.Id, user.Username, Roles = user.Roles.Select(r => r.RoleName) });
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshRequest request)
    {
        var tokens = await _authService.RefreshTokenAsync(request.RefreshToken);
        if (tokens == null)
            return Unauthorized("Invalid or expired refresh token.");

        return Ok(new
        {
            AccessToken = tokens.Value.AccessToken,
            RefreshToken = tokens.Value.RefreshToken
        });
    }

    [HttpPost("revoke")]
    [Authorize]
    public async Task<IActionResult> Revoke()
    {
        var username = User.Identity?.Name;
        if (string.IsNullOrEmpty(username)) return BadRequest("Invalid user.");

        await _authService.RevokeRefreshTokenAsync(username);
        return NoContent();
    }
}

public class LoginRequest
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}

public class RegisterRequest
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    public string[] Roles { get; set; } = System.Array.Empty<string>();
}

public class RefreshRequest
{
    [Required]
    public string RefreshToken { get; set; } = string.Empty;
}
