using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Patients.Command.GreatPatient;
using Hospital_ERP_Backend.Application.Features.Patients.Command.UpdatePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Command.DeletePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients;
using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetIDPatient;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Roles.Extensions
{
    public static class PateintServiceExtensions
    {
        public static IServiceCollection AddRoPatientExtension(this IServiceCollection Services)
        {
            Services.AddScoped<IValidator<CreatePatient>, CreatePatientValidator>();
            Services.AddScoped<IValidator<UpdatePatient>, UpdatePatientValidator>();
            Services.AddScoped<IValidator<DeletePatient>, DeletePatientValidator>();
            Services.AddScoped<IValidator<GetAllPatient>, GetAllPatientValidator>();
            Services.AddScoped<IValidator<GetIDPatient>, GetIDPatientValidator>();

            Services.AddScoped<CreatePatientService>();
            Services.AddScoped<UpdatePatientService>();
            Services.AddScoped<DeletePatientService>();
            Services.AddScoped<GetAllPatientService>();
            Services.AddScoped<GetIDPateintService>();
            return Services;
        }
    }
}
