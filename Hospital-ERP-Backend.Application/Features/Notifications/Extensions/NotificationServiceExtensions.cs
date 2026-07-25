using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Notifications.Queries.GetAllNotifications;
using Hospital_ERP_Backend.Application.Features.Notifications.Queries.GetNotification;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Extensions
{
    public static class NotificationServiceExtensions
    {
        public static IServiceCollection AddNotificationsServicesExtension(this IServiceCollection services)
        {

            services.AddScoped<IValidator<GetNotificationRequest>, GetNotificationValidator>();
            services.AddScoped<IValidator<GetAllNotificationsRequest>, GetAllNotificationsValidator>();

            services.AddScoped<GetNotificationService>();
            services.AddScoped<GetAllNotificationsService>();


            return services;
        }
    }
}
