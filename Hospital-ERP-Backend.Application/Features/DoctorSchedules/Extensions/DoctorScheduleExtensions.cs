using FluentValidation;
using Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.CreateDoctorSchedule;
using Hospital_ERP_Backend.Application.Features.DoctorSchedules.Queries.GetAllDoctorSchedules;
using Hospital_ERP_Backend.Application.Features.DoctorSchedules.Queries.GetDoctorSchedule;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Extensions
{
    public static class DoctorScheduleExtensions
    {

        public static IServiceCollection AddDoctorScheduleServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllDoctorSchedulesRequest>, GetAllDoctorSchedulesValidator>();
            services.AddScoped<IValidator<GetDoctorScheduleRequest>, GetDoctorScheduleValidator>();
            services.AddScoped<IValidator<CreateDoctorScheduleRequest>, CreateDoctorScheduleValidator>();


            services.AddScoped<GetAllDoctorSchedulesService>();
            services.AddScoped<GetDoctorScheduleService>();
            services.AddScoped<CreateDoctorScheduleService>();

            return services;
        }
    }
}
