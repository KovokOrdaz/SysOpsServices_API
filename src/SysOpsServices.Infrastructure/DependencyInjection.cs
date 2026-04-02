using Microsoft.Extensions.DependencyInjection;
using SysOpsServices.Application.Interfaces;
using SysOpsServices.Application.Services;
using SysOpsServices.Domain.Interfaces;
using SysOpsServices.Infrastructure.Data;
using SysOpsServices.Infrastructure.Repositories;
using SysOpsServices.Infrastructure.Services;

namespace SysOpsServices.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        // DB connection factory
        services.AddSingleton<IDbConnectionFactory>(
            _ => new MariaDbConnectionFactory(connectionString));

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();

        // Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
