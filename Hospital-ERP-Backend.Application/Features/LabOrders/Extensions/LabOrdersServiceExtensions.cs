using FluentValidation;
using Hospital_ERP_Backend.Application.Features.LabOrders.Commands.CreateLabOrder;
using Hospital_ERP_Backend.Application.Features.LabOrders.Commands.UpdateLabOrder;
using Hospital_ERP_Backend.Application.Features.LabOrders.Queries.GetAllLabOrders;
using Hospital_ERP_Backend.Application.Features.LabOrders.Queries.GetLabOrder;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Extensions
{
    public static class LabOrdersServiceExtensions
    {
        public static IServiceCollection AddLabOrdersServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetLabOrderRequest>, GetLabOrderValidator>();
            services.AddScoped<IValidator<GetAllLabOrdersRequest>, GetAllLabOrdersValidator>();
            services.AddScoped<IValidator<CreateLabOrderRequest>, CreateLabOrderValidator>();
            services.AddScoped<IValidator<UpdateLabOrderRequest>, UpdateLabOrderValidator>();

            services.AddScoped<GetLabOrderService>();
            services.AddScoped<GetAllLabOrdersService>();
            services.AddScoped<UpdateLabOrderService>();

            return services;
        }
    }
}
