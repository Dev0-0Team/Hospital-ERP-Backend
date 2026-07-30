using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Allergies.Commands.CreateAllergy;
using Hospital_ERP_Backend.Application.Features.Allergies.Queries.GetAllAllergies;
using Hospital_ERP_Backend.Application.Features.Allergies.Queries.GetAllergy;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Extensions
{
    public static class AllergyServiceExtensions
    {
        public static IServiceCollection AddAllergyServicesExtension(this IServiceCollection service)
        {
            service.AddScoped<IValidator<GetAllergyRequest>, GetAllergyValidator>();
            service.AddScoped<IValidator<GetAllAllergiesRequest>, GetAllAllergiesValidator>();
            service.AddScoped<IValidator<CreateAllergyRequest>, CreateAllergyValidator>();

            service.AddScoped<GetAllergyService>();
            service.AddScoped<GetAllAllergiesService>();
            service.AddScoped<CreateAllergyService>();

            return service;
        }
    }
}
