using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Security
{
    public static class JWTTokenServiceExtensions
    {
        public static IServiceCollection AddJwtTokenServicesExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddSingleton<JwtTokenService>();
            services.AddScoped<JwtTokenService>();
            return services;
        }
    }
}
