using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Prescriptions.Queries.GetPrescription;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Extensions
{
    public static class PrescriptionsServiceExtesnsion
    {

        public static IServiceCollection AddPrescriptionsExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetPrescriptionRequest>, GetPrescriptionValidator>();

            services.AddScoped<GetPrescriptionService>();

            return services;
        }
    }
}
