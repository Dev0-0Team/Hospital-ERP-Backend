using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Allergies.Queries.GetAllergy;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Extensions
{
    public static class AllergyServiceExtensions
    {
        public static IServiceCollection AddAllergyServicesExtension(this IServiceCollection service)
        {
            service.AddScoped<IValidator<GetAllergyRequest>, GetAllergyValidator>();

            service.AddScoped<GetAllergyService>();

            return service;
        }
    }
}
