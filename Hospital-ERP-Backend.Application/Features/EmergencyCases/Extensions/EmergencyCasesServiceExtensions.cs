using FluentValidation;
using Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.CreateEmergencyCases;
using Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.DeleteEmergencyCases;
using Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.UpdateEmergencyCases;
using Hospital_ERP_Backend.Application.Features.EmergencyCases.Queries.GetAllEmergencyCases;
using Hospital_ERP_Backend.Application.Features.EmergencyCases.Queries.GetEmergencyCase;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Extensions
{
    public static class EmergencyCasesServiceExtensions
    {
        public static IServiceCollection AddEmergencyCasesServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllEmergencyCasesRequest>, GetAllEmergencyCasesValidator>();
            services.AddScoped<IValidator<GetEmergencyCaseRequest>, GetEmergencyCaseValidator>();
            services.AddScoped<IValidator<CreateEmergencyCasesRequest>, CreateEmergencyCasesValidator>();
            services.AddScoped<IValidator<UpdateEmergencyCasesRequest>, UpdateEmergencyCasesValidator>();
            services.AddScoped<IValidator<DeleteEmergencyCasesRequest>, DeleteEmergencyCasesValidator>();

            return services;
        }
    }
}

