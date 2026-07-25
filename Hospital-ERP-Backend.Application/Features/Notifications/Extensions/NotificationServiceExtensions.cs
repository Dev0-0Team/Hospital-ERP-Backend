using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Notifications.Queries.GetNotification;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Extensions
{
    public static class NotificationServiceExtensions
    {
        public static IServiceCollection AddNotificationsServicesExtension(this IServiceCollection services)
        {

            services.AddScoped<IValidator<GetNotificationRequest>, GetNotificationValidator>();

            services.AddScoped<GetNotificationService>();


            return services;
        }
    }
}
