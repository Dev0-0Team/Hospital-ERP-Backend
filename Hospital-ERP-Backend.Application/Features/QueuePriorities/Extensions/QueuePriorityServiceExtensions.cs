using FluentValidation;
using Hospital_ERP_Backend.Application.Features.QueuePriorities.Queries.GetAllQueuePriorities;
using Hospital_ERP_Backend.Application.Features.QueuePriorities.Queries.GetQueuePriority;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Extensions
{
    public static class QueuePriorityServiceExtensions
    {
       
        public static IServiceCollection AddQueuePriorityServicesExtension(this IServiceCollection Services)
        {
            Services.AddScoped<IValidator<GetAllQueuePrioritiesRequest>, GetAllQueuePrioritiesValidator>();
            Services.AddScoped<GetAllQueuePrioritiesService>();
            Services.AddScoped<IValidator<GetQueuePriorityRequest>, GetQueuePriorityValidator>();
            Services.AddScoped<GetQueuePriorityService>();

            return Services;
        }
    }
}