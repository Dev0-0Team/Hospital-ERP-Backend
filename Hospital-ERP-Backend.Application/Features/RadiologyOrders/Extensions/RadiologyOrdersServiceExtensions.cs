using FluentValidation;
using Hospital_ERP_Backend.Application.Features.RadiologyOrders.Queries.GetAllRadiologyOrders;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Extensions
{
    public static class RadiologyOrdersServiceExtensions
    {
        public static IServiceCollection RadiologyOrdersServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllRadiologyOrdersRequest>, GetAllRadiologyOrdersValidator>();

            services.AddScoped<GetAllRadiologyOrdersService>();


            return services;
        }
    }
}
