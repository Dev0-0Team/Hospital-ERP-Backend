using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Patients.Commands.CreatePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Commands.DeletePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Commands.UpdatePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients;
using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetPatient;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Patients.Extensions
{
    public static class PatientServicesExtension
    {
        public static IServiceCollection AddPatientServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetPatientRequest>, GetPatientValidator>();
            services.AddScoped<IValidator<GetAllPatientsRequest>, GetAllPatientsValidator>();
            services.AddScoped<IValidator<CreatePatientRequest>, CreatePatientValidator>();
            services.AddScoped<IValidator<UpdatePatientRequest>, UpdatePatientValidator>();
            services.AddScoped<IValidator<DeletePatientRequest>, DeletePatientValidator>();

            services.AddScoped<GetAllPatientsService>();
            services.AddScoped<GetPatientService>();
            services.AddScoped<UpdatePatientService>();
            services.AddScoped<DeletePatientService>();
            services.AddScoped<CreatePatientService>();
            return services;
        }
    }
}
