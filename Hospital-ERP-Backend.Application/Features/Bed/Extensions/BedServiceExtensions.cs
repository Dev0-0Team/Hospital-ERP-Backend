using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Beds.Queries.GetAllBeds;
using Hospital_ERP_Backend.Application.Features.Beds.Queries.GetBed;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Beds.Extensions
{
    public static class BedServiceExtensions
    {
        public static IServiceCollection AddBedServicesExtension(this IServiceCollection Services)
        {
            Services.AddScoped<IValidator<GetAllBedsRequest>, GetAllBedsValidator>();
            Services.AddScoped<IValidator<GetBedRequest>, GetBedValidator>();

            Services.AddScoped<GetAllBedsService>();
            Services.AddScoped<GetBedService>();
            return Services;
        }
    }
}