using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Allergys.Commamds.DeleteAllergy;
using Hospital_ERP_Backend.Application.Features.Allergys.Commands.CreateAllergy;
using Hospital_ERP_Backend.Application.Features.Allergys.Commands.DeleteAllergy;
using Hospital_ERP_Backend.Application.Features.Allergys.Commands.UpdateAllergy;
using Hospital_ERP_Backend.Application.Features.Allergys.Queries.GetAllAllergy;
using Hospital_ERP_Backend.Application.Features.Allergys.Queries.GetAllergy;

using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Allergys.Extensions
{
    public static class AllergyServiceExtensions
    {
        public static IServiceCollection AddAllergyServicesExtension(this IServiceCollection Services)
        {
            Services.AddScoped<IValidator<DeleteAllergyRequest>, DeleteAllergyValidator>();
            Services.AddScoped<IValidator<CreateAllergyRequest>, CreateAllergyValidator>();
            Services.AddScoped<IValidator<UpdateAllergyRequest>, UpdateAllergyValidator>();
            Services.AddScoped<IValidator<GetAllAllergyRequest>, GetAllAllergyValidator>();
            Services.AddScoped<IValidator<GetAllergyRequest>, GetAllergyValidator>();

            Services.AddScoped<DeleteAllergyService>();
            Services.AddScoped<CreateAllergyService>();
            Services.AddScoped<UpdateAllergyService>();
            Services.AddScoped<GetAllAllergyService>();
            Services.AddScoped<GetAllergyService>();
            return Services;
        }
    }
}