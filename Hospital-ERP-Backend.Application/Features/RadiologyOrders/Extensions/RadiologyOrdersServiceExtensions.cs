using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Appointments.Queries.GetAllAppointments;
using Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.CreateRadiologyOrder;
using Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.UpdateQueuePriority;
using Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.UpdateRadiologyOrder;
using Hospital_ERP_Backend.Application.Features.RadiologyOrders.Queries.GetAllRadiologyOrders;
using Hospital_ERP_Backend.Application.Features.RadiologyOrders.Queries.GetRadiologyOrder;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Extensions
{
    public static class RadiologyOrdersServiceExtensions
    {
        public static IServiceCollection AddRadiologyOrdersServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllRadiologyOrdersRequest>, GetAllRadiologyOrdersValidator>();
            services.AddScoped<IValidator<GetRadiologyOrderRequest>, GetRadiologyOrderValidator>();
            services.AddScoped<IValidator<CreateRadiologyOrderRequest>, CreateRadiologyOrderValidator>();
            services.AddScoped<IValidator<UpdateRadiologyOrderRequest>, UpdateRadiologyOrderValidator>();

            services.AddScoped<GetAllRadiologyOrdersService>();
            services.AddScoped<GetAllAppointmentsService>();
            services.AddScoped<CreateRadiologyOrderService>();
            services.AddScoped<UpdateRadiologyOrderService>();
            return services;
        }
    }
}
