using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using ToDoApp.Models;
using ToDoApp.Services;

namespace TodoApp.Middlewares;

public class GlobalAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IUserRepository _userRepository;
    public GlobalAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IUserRepository userRepository )
         : base(options, logger, encoder, clock)
    {
        _userRepository = userRepository;
    }
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if(!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("Missing Authorization Header");
        }

        User? user;
        try
        {
            if(!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"],out var authHeader))
            {
                return AuthenticateResult.Fail("Invalid Authorization Header Format");
            }
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter ?? string.Empty);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':',2);

            if(credentials.Length != 2)
            {
                return AuthenticateResult.Fail("Invalid AUthorization Header Content");
            }

            var username = credentials[0];
            var password = credentials[1];

            user = await _userRepository.ValidateUser(username, password);

        }
        catch(FormatException)
        {
             return AuthenticateResult.Fail("Invalid Base64 Encoding in Authorization Header");
            
        }
        catch (Exception)
        {
            return AuthenticateResult.Fail("Error Processing Authorization Header");
        }
        if (user == null)
        {
            return AuthenticateResult.Fail("Invalid Username or Password");
        }
        
        var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            claims.AddRange(user.Roles.Select(role
                => new Claim(ClaimTypes.Role, role.RoleName)));

            var identity = new ClaimsIdentity(claims, Scheme.Name);

            var principal = new ClaimsPrincipal(identity);

            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
    }
    protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
    {
        Response.Headers["WWW-Authenticate"] = "Basic realm=\"BasicAuthWebAPI\", charset=\"UTF-8\"";

        Response.StatusCode = 401;

        await Response.WriteAsync("You need to authenticate to access this resource.");
    }
}