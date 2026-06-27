using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EduMentorAI.Api.Extensions;

public static class JwtServiceExtensions
{
    public static IServiceCollection AddJwtAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string key = configuration["Jwt:Key"]
                     ?? throw new InvalidOperationException("No se encontró Jwt:Key.");

        string issuer = configuration["Jwt:Issuer"]
                        ?? throw new InvalidOperationException("No se encontró Jwt:Issuer.");

        string audience = configuration["Jwt:Audience"]
                          ?? throw new InvalidOperationException("No se encontró Jwt:Audience.");

        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),

                    ValidateIssuer = true,
                    ValidIssuer = issuer,

                    ValidateAudience = true,
                    ValidAudience = audience,

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        return services;
    }
}