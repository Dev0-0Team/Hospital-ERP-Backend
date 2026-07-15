using FluentValidation;
using Hospital_ERP_Backend.Application.Features.LabOrders.Queries.GetAllLabOrders;
using Hospital_ERP_Backend.Application.Features.LabTestResults.Queries.GetLabTestResult;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Extensions
{
    public static class LabTestResultsServiceExtensions
    {
        public static IServiceCollection AddLabTestResultsServiceExtension(this IServiceCollection services)
        {

            services.AddScoped<IValidator<GetAllLabOrdersRequest>, GetAllLabOrdersValidator>();

            services.AddScoped<IValidator<GetLabTestResultRequest>, GetLabTestResultValidator>();

            services.AddScoped<GetLabTestResultService>();
            services.AddScoped<GetAllLabOrdersService>();
            return services;
        }

    }
}
