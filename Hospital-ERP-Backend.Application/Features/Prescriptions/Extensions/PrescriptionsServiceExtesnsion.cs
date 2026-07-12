using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.CreatePrescription;
using Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.UpdatePrescription;
using Hospital_ERP_Backend.Application.Features.Prescriptions.Queries.GetAllPrescriptions;
using Hospital_ERP_Backend.Application.Features.Prescriptions.Queries.GetPrescription;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Extensions
{
    public static class PrescriptionsServiceExtesnsion
    {

        public static IServiceCollection AddPrescriptionsExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetPrescriptionRequest>, GetPrescriptionValidator>();
            services.AddScoped<IValidator<GetAllPrescriptionsRequest>, GetAllPrescriptionsValidator>();
            services.AddScoped<IValidator<CreatePrescriptionRequest>, CreatePrescriptionValidator>();
            services.AddScoped<IValidator<UpdatePrescriptionRequest>, UpdatePrescriptionValidator>();

            services.AddScoped<GetPrescriptionService>();
            services.AddScoped<GetAllPrescriptionsService>();
            services.AddScoped<CreatePrescriptionService>();
            services.AddScoped<UpdatePrescriptionService>();
            return services;
        }
    }
}
