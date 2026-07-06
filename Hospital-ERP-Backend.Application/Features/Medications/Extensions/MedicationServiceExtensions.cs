using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Medications.Commands.CreateMedication;
using Hospital_ERP_Backend.Application.Features.Medications.Commands.DeleteMedication;
using Hospital_ERP_Backend.Application.Features.Medications.Commands.UpdateMedication;
using Hospital_ERP_Backend.Application.Features.Medications.Queries.GetAllMedications;
using Hospital_ERP_Backend.Application.Features.Medications.Queries.GetMedicationById;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Medications.Extensions
{
    public static class MedicationServiceExtensions
    {
        public static IServiceCollection AddMedicationServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetMedicationRequest>, GetMedicationValidator>();
            services.AddScoped<IValidator<GetAllMedicationsRequest>, GetAllMedicationsValidator>();
            services.AddScoped<IValidator<CreateMedicationRequest>, CreateMedicationValidator>();
            services.AddScoped<IValidator<DeleteMedicationRequest>, DeleteMedicationValidator>();
            services.AddScoped<IValidator<UpdateMedicationRequest>, UpdateMedicationValidator>();


            services.AddScoped<CreateMedicationService>();
            services.AddScoped<UpdateMedicationService>();
            services.AddScoped<DeleteMedicationService>();
            services.AddScoped<GetMedicationService>();
            services.AddScoped<GetAllMedicationsService>();


            return services;
        }
    }
}
