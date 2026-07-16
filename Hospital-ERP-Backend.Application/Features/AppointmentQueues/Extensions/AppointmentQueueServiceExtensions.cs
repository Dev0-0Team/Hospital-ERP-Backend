using FluentValidation;
using Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.CreateAppointmentQueue;
using Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.UpdateAppointmentQueue;
using Hospital_ERP_Backend.Application.Features.AppointmentQueues.Queries.GetAllAppointmentQueues;
using Hospital_ERP_Backend.Application.Features.AppointmentQueues.Queries.GetAppointmentQueue;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Extensions
{
    public static class AppointmentQueueServiceExtensions
    {
        public static IServiceCollection AddAppointmentQueueServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllAppointmentQueuesRequest>, GetAllAppointmentQueuesValidator>();
            services.AddScoped<IValidator<GetAppointmentQueueRequest>, GetAppointmentQueueValidator>();
            services.AddScoped<IValidator<CreateAppointmentQueueRequest>, CreateAppointmentQueueValidator>();
            services.AddScoped<IValidator<UpdateAppointmentQueueRequest>, UpdateAppointmentQueueValidator>();

            services.AddScoped<GetAllAppointmentQueuesService>();
            services.AddScoped<GetAppointmentQueueService>();
            services.AddScoped<CreateAppointmentQueueService>();
            services.AddScoped<UpdateAppointmentQueueService>();

            return services;
        }
    }
}