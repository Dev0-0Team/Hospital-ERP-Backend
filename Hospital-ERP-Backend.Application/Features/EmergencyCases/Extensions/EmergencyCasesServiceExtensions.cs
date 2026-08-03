using FluentValidation;
using Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.CreateEmergencyCases;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Extensions
{
    public static class EmergencyCasesServiceExtensions
    {
        public static IServiceCollection AddEmergencyCasesServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateEmergencyCasesRequest >, CreateEmergencyCasesValidator>();
            //services.AddScoped<CreateEmergencyCasesService>();

            return services;
        }
    }
}
