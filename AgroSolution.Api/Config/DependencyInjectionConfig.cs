using AgroSolution.Core.App.Features.Auth;
using AgroSolution.Core.App.Features.Register;
using AgroSolution.Core.App.Features.TokenJwt;
using AgroSolution.Core.Domain.Interfaces;
using AgroSolution.Core.Infra.Data;
using AgroSolution.Core.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AgroSolution.Auth.Config;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AgroIdentityDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRegisterService, RegisterService>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}