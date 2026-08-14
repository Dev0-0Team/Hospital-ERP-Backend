using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Authentication.Commands.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Authentication.Extensions
{
    public static class AuthServiceExtensions
    {
        public static IServiceCollection AddAuthServiceExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RegisterRequest>, RegisterValidator>();

            services.AddScoped<RegisterService>();
            return services;
        }
    }
}
