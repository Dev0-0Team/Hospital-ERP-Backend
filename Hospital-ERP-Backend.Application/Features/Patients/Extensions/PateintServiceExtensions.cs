using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Patients.Command.UpdatePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Commands.CreatePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Commands.DeletePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Commands.GreatePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Commands.UpdatePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients;
using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetIDPatient;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Roles.Extensions
{
    public static class PatientServiceExtensions
    {
        public static IServiceCollection AddRoPatientExtension(this IServiceCollection Services)
        {
            Services.AddScoped<IValidator<CreatePatientRequest>, CreatePatientValidator>();
            Services.AddScoped<IValidator<UpdatePatientRequest>, UpdatePatientValidator>();
            Services.AddScoped<IValidator<DeletePatientRequest>, DeletePatientValidator>();
            Services.AddScoped<IValidator<GetAllPatientRequest>, GetAllPatientValidator>();
            Services.AddScoped<IValidator<GetPateintRequest>, GetPatientValidator>();

            Services.AddScoped<CreatePatientService>();
            Services.AddScoped<UpdatePatientService>();
            Services.AddScoped<DeletePatientService>();
            Services.AddScoped<GetAllPatientService>();
            Services.AddScoped<GetPateintService>();
            return Services;
        }
    }
}
