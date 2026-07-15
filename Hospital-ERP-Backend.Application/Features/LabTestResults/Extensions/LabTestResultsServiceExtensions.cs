using FluentValidation;
using Hospital_ERP_Backend.Application.Features.LabTestResults.Commands.CreateLabTestResult;
using Hospital_ERP_Backend.Application.Features.LabTestResults.Commands.DeleteLabTestResult;
using Hospital_ERP_Backend.Application.Features.LabTestResults.Commands.UpdateLabTestResult;
using Hospital_ERP_Backend.Application.Features.LabTestResults.Queries.GetAllLabTestResults;
using Hospital_ERP_Backend.Application.Features.LabTestResults.Queries.GetLabTestResult;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Extensions
{
    public static class LabTestResultsServiceExtensions
    {
        public static IServiceCollection AddLabTestResultsServiceExtension(this IServiceCollection services)
        {

            services.AddScoped<IValidator<GetAllLabTestResultsRequest>, GetAllLabTestResultsValidator>();

            services.AddScoped<IValidator<GetLabTestResultRequest>, GetLabTestResultValidator>();
            services.AddScoped<IValidator<CreateLabTestResultRequest>, CreateLabTestResultValidator>();
            services.AddScoped<IValidator<UpdateLabTestResultRequest>, UpdateLabTestResultValidator>();
            services.AddScoped<IValidator<DeleteLabTestResultRequest>, DeleteLabTestResultValidator>();

            services.AddScoped<GetLabTestResultService>();
            services.AddScoped<GetAllLabTestResultsService>();
            services.AddScoped<CreateLabTestResultService>();
            services.AddScoped<UpdateLabTestResultService>();
            services.AddScoped<DeleteLabTestResultService>();
            return services;
        }

    }
}
