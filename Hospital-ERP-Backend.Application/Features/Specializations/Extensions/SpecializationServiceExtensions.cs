using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Specializations.Commands.CreateSpecialization;
using Hospital_ERP_Backend.Application.Features.Specializations.Commands.DeleteSpecialization;
using Hospital_ERP_Backend.Application.Features.Specializations.Commands.UpdateSpecialization;
using Hospital_ERP_Backend.Application.Features.Specializations.Queries.GetAllSpecializations;
using Hospital_ERP_Backend.Application.Features.Specializations.Queries.GetSpecialization;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Specializations.Extensions
{
    public static class SpecializationServiceExtensions
    {
        public static IServiceCollection AddSpecializationServicesExtension(this IServiceCollection Services)
        {
            Services.AddScoped<IValidator<GetAllSpecializationsRequest>, GetAllSpecializationsValidator>();
            Services.AddScoped<IValidator<GetSpecializationRequest>, GetSpecializationValidator>();
            Services.AddScoped<IValidator<CreateSpecializationRequest>, CreateSpecializationValidator>();
            Services.AddScoped<IValidator<UpdateSpecializationRequest>, UpdateSpecializationValidator>();
            Services.AddScoped<IValidator<DeleteSpecializationRequest>, DeleteSpecializationValidator>();

            Services.AddScoped<GetAllSpecializationsService>();
            Services.AddScoped<GetSpecializationService>();
            Services.AddScoped<CreateSpecializationService>();
            Services.AddScoped<UpdateSpecializationService>();
            Services.AddScoped<DeleteSpecializationService>();
            return Services;
        }
    }
}