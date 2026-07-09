using FluentValidation;
using Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.CreateQueuePriority;
using Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.DeleteQueuePriority;
using Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.UpdateQueuePriority;
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
            Services.AddScoped<IValidator<GetQueuePriorityRequest>, GetQueuePriorityValidator>();
            Services.AddScoped<IValidator<CreateQueuePriorityRequest>, CreateQueuePriorityValidator>();
            Services.AddScoped<IValidator<UpdateQueuePriorityRequest>, UpdateQueuePriorityValidator>();
            Services.AddScoped<IValidator<DeleteQueuePriorityRequest>, DeleteQueuePriorityValidator>();

            Services.AddScoped<GetAllQueuePrioritiesService>();
            Services.AddScoped<GetQueuePriorityService>();
            Services.AddScoped<CreateQueuePriorityService>();
            Services.AddScoped<UpdateQueuePriorityService>();
            Services.AddScoped<DeleteQueuePriorityService>();

            return Services;
        }
    }
}