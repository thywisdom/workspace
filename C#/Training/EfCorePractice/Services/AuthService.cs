using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EfCorePractice.Data;
using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EfCorePractice.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<(string AccessToken, string RefreshToken)?> AuthenticateAsync(string username, string password)
    {
        var user = await _context.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

        if (user == null) return null;

        var tokens = await GenerateTokensAsync(user);
        return tokens;
    }

    public async Task<(string AccessToken, string RefreshToken)?> RefreshTokenAsync(string refreshToken)
    {
        var tokenRecord = await _context.RefreshTokens
            .Include(rt => rt.User)
            .ThenInclude(u => u.Roles)
            .FirstOrDefaultAsync(rt => rt.Token == refreshToken);

        if (tokenRecord == null || tokenRecord.ExpiryDate <= DateTime.UtcNow)
        {
            return null;
        }

        // Revoke the old refresh token (sliding expiration)
        _context.RefreshTokens.Remove(tokenRecord);
        await _context.SaveChangesAsync();

        return await GenerateTokensAsync(tokenRecord.User);
    }

    public async Task<bool> RevokeRefreshTokenAsync(string username)
    {
        var tokenRecords = await _context.RefreshTokens.Where(rt => rt.Username == username).ToListAsync();
        if (!tokenRecords.Any()) return false;

        _context.RefreshTokens.RemoveRange(tokenRecords);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<User?> GetUserAsync(string username)
    {
        return await _context.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User> RegisterUserAsync(string username, string password, string[] roles)
    {
        var user = new User { Username = username, Password = password };
        var existingRoles = await _context.Roles.Where(r => roles.Contains(r.RoleName)).ToListAsync();
        

        var newRoles = roles.Except(existingRoles.Select(r => r.RoleName)).Select(r => new Role { RoleName = r }).ToList();
        if(newRoles.Any()) {
            _context.Roles.AddRange(newRoles);
        }
        
        user.Roles = existingRoles.Concat(newRoles).ToList();
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    private async Task<(string AccessToken, string RefreshToken)> GenerateTokensAsync(User user)
    {
        var keyStr = _configuration["JwtSettings:Key"];
        var issuer = _configuration["JwtSettings:Issuer"];
        var audience = _configuration["JwtSettings:Audience"];
        var expiryMins = int.Parse(_configuration["JwtSettings:AccessTokenExpirationMinutes"] ?? "15");
        var refreshDays = int.Parse(_configuration["JwtSettings:RefreshTokenExpirationDays"] ?? "7");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var role in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
        }

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMins),
            signingCredentials: creds
        );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
        var refreshToken = GenerateRefreshToken();

        var refreshTokenEntity = new RefreshToken
        {
            Token = refreshToken,
            Username = user.Username,
            ExpiryDate = DateTime.UtcNow.AddDays(refreshDays),
            UserId = user.Id
        };

        _context.RefreshTokens.Add(refreshTokenEntity);
        await _context.SaveChangesAsync();

        return (accessToken, refreshToken);
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}
