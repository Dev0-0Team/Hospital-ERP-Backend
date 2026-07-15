using FluentValidation;
using Hospital_ERP_Backend.Application.Features.RadiologyImages.Queries.GetAllRadiologyImages;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Extensions
{
    public static class RadiologyImagesServicesExtension
    {

        public static IServiceCollection AddRadiologyImageServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllRadiologyImagesRequest>, GetAllRadiologyImagesValidator>();


            services.AddScoped<GetAllRadiologyImagesService>();
            return services;
        }
    }
}
