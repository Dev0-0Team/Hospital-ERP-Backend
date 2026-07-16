using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Doctors.Commands.CreateDoctor;
using Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetAllDoctors;
using Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetDoctor;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Extensions
{
    public static class DoctorsServicesExtension
    {
        public static IServiceCollection AddDoctorsServicesExtension(this IServiceCollection services)
        {

            services.AddScoped<IValidator<GetAllDoctorsRequest>, GetAllDoctorsValidator>();
            services.AddScoped<IValidator<GetDoctorRequest>, GetDoctorValidator>();
            services.AddScoped<IValidator<CreateDoctorRequest>, CreateDoctorValidator>();

            services.AddScoped<GetAllDoctorsService>();
            services.AddScoped<GetDoctorService>();
            services.AddScoped<CreateDoctorRequest>();

            return services;
        }
    }
}
