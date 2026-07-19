using FluentValidation;
using Hospital_ERP_Backend.Application.Features.DoctorSchedules.Queries.GetAllDoctorSchedules;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Extensions
{
    public static class DoctorScheduleExtensions
    {

        public static IServiceCollection AddDoctorScheduleServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllDoctorSchedulesRequest>, GetAllDoctorSchedulesValidator>();


            services.AddScoped<GetAllDoctorSchedulesService>();

            return services;
        }
    }
}
