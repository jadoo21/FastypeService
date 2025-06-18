using FastypeService.Repositories.Interfaces;
using FastypeService.Repositories;
using FastypeService.Services.Interfaces;
using FastypeService.Services;

namespace FastypeService.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // Register Services
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
