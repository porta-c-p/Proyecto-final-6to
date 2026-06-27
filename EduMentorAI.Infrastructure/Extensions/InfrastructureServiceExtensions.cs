using EduMentorAI.Application.Interfaces;
using EduMentorAI.Infrastructure.Persistence.Context;
using EduMentorAI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduMentorAI.Infrastructure.Extensions;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection")
                                  ?? throw new InvalidOperationException(
                                      "No se encontró la cadena de conexión DefaultConnection.");

        services.AddDbContext<EduMentorAiDbContext>(options =>
            options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}