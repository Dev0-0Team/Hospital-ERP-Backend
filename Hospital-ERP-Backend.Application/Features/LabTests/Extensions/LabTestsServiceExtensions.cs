using FluentValidation;
using Hospital_ERP_Backend.Application.Features.LabTests.Commands.CreateLabTest;
using Hospital_ERP_Backend.Application.Features.LabTests.Commands.DeleteLabTest;
using Hospital_ERP_Backend.Application.Features.LabTests.Commands.UpdateLabTest;
using Hospital_ERP_Backend.Application.Features.LabTests.Queries.GetLabTest;
using Hospital_ERP_Backend.Application.Features.LapTests.Queries.GetAllLabTests;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Extensions
{
    public static class LabTestsServiceExtensions
    {
        public static IServiceCollection AddLabTestsServices(this IServiceCollection services)
        {

            services.AddScoped<IValidator<CreateLabTestRequest>, CreateLabTestValidator>();
            services.AddScoped<IValidator<UpdateLabTestRequest>, UpdateLabTestValidator>();
            services.AddScoped<IValidator<DeleteLabTestRequest>, DeleteLabTestValidator>();
            services.AddScoped<IValidator<GetLabTestRequest>, GetLabTestValidator>();
            services.AddScoped<IValidator<GetAllLabTestsRequest>, GetAllLabTestsValidator>();

            services.AddScoped<GetAllLabTestsService>();
            services.AddScoped<GetLabTestService>();
            services.AddScoped<UpdateLabTestService>();
            services.AddScoped<DeleteLabTestService>();
            services.AddScoped<CreateLabTestService>();
            return services;
        }
    }
}
