using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Appointments.Commands.CreateAppointment;
using Hospital_ERP_Backend.Application.Features.Appointments.Commands.DeleteAppointment;
using Hospital_ERP_Backend.Application.Features.Appointments.Commands.UpdateAppointment;
using Hospital_ERP_Backend.Application.Features.Appointments.Queries.GetAllAppointments;
using Hospital_ERP_Backend.Application.Features.Appointments.Queries.GetAppointment;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Extensions
{
    public static class AppointmentServiceExtensions
    {
        public static IServiceCollection AddAppointmentServicesExtension(this IServiceCollection services)
        {
        
            services.AddScoped<IValidator<GetAppointmentRequest>, GetAppointmentValidator>();
            services.AddScoped<IValidator<GetAllAppointmentsRequest>, GetAllAppointmentsValidator>();
            services.AddScoped<IValidator<CreateAppointmentRequest>, CreateAppointmentValidator>();
            services.AddScoped<IValidator<UpdateAppointmentRequest>, UpdateAppointmentValidator>();
            services.AddScoped<IValidator<DeleteAppointmentRequest>, DeleteAppointmentValidator>();

       
            services.AddScoped<GetAppointmentService>();
            services.AddScoped<GetAllAppointmentsService>();
            services.AddScoped<CreateAppointmentService>();
            services.AddScoped<UpdateAppointmentService>();
            services.AddScoped<DeleteAppointmentService>();
            return services;
        }
    }
}