using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetAllDoctors;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Extensions
{
    public static class DoctorsServicesExtension
    {
        public static IServiceCollection AddDoctorsServicesExtension(this IServiceCollection services)
        {

            services.AddScoped<IValidator<GetAllDoctorsRequest>, GetAllDoctorsValidator>();

            services.AddScoped<GetAllDoctorsService>();

            return services;
        }
    }
}
