using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EduMentorAI.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EduMentorAI.Infrastructure.Services;

public sealed class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(
        int userId,
        string fullName,
        string email,
        string role)
    {
        string key = _configuration["Jwt:Key"]
                     ?? throw new InvalidOperationException("No se encontró Jwt:Key.");

        string issuer = _configuration["Jwt:Issuer"]
                        ?? throw new InvalidOperationException("No se encontró Jwt:Issuer.");

        string audience = _configuration["Jwt:Audience"]
                          ?? throw new InvalidOperationException("No se encontró Jwt:Audience.");

        string expiresValue = _configuration["Jwt:ExpiresInMinutes"] ?? "120";

        int expiresInMinutes = int.Parse(expiresValue);

        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        List<Claim> claims =
        [
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, fullName),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, role)
        ];

        SigningCredentials credentials = new(
            new SymmetricSecurityKey(keyBytes),
            SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiresInMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}