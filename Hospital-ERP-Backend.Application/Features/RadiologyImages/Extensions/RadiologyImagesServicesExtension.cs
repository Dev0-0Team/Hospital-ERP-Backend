using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Appointments.Commands.CreateAppointment;
using Hospital_ERP_Backend.Application.Features.RadiologyImages.Queries.GetAllRadiologyImages;
using Hospital_ERP_Backend.Application.Features.RadiologyImages.Queries.GetRadiologyImage;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Extensions
{
    public static class RadiologyImagesServicesExtension
    {

        public static IServiceCollection AddRadiologyImageServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllRadiologyImagesRequest>, GetAllRadiologyImagesValidator>();
            services.AddScoped<IValidator<GetRadiologyImageRequest>, GetRadiologyImageValidator>();
            services.AddScoped<IValidator<CreateAppointmentRequest>, CreateAppointmentValidator>();

            services.AddScoped<GetAllRadiologyImagesService>();
            services.AddScoped<GetRadiologyImageService>();
            services.AddScoped<CreateAppointmentService>();
            return services;
        }
    }
}
