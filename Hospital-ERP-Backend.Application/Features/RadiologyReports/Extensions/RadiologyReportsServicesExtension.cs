using FluentValidation;
using Hospital_ERP_Backend.Application.Features.RadiologyReports.Queries.GetAllRadiologyReports;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Extensions
{
    public static class RadiologyReportsServicesExtension
    {
        public static IServiceCollection AddRadiologyReportsServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllRadiologyReportsRequest>, GetAllRadiologyReportsValidator>();


            services.AddScoped<GetAllRadiologyReportsService>();

            return services;
        }
    }
}
