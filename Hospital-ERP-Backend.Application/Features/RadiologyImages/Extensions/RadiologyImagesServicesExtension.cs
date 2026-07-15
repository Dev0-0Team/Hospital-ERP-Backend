using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Appointments.Commands.CreateAppointment;
using Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.CreateRadiologyImage;
using Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.DeleteRadiologyImage;
using Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.UpdateRadiologyImage;
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
            services.AddScoped<IValidator<CreateRadiologyImageRequest>, CreateRadiologyImageValidator>();
            services.AddScoped<IValidator<UpdateRadiologyImageRequest>, UpdateRadiologyImageValidator>();
            services.AddScoped<IValidator<DeleteRadiologyImageRequest>, DeleteRadiologyImageValidator>();

            services.AddScoped<GetAllRadiologyImagesService>();
            services.AddScoped<GetRadiologyImageService>();
            services.AddScoped<CreateAppointmentService>();
            services.AddScoped<UpdateRadiologyImageService>();
            services.AddScoped<DeleteRadiologyImageService>();

            return services;
        }
    }
}
