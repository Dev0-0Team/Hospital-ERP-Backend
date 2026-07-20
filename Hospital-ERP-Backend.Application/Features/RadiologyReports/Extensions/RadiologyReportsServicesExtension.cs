using FluentValidation;
using Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.CreateRadiologyReport;
using Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.DeleteRadiologyReport;
using Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.UpdateRadiologyReport;
using Hospital_ERP_Backend.Application.Features.RadiologyReports.Queries.GetAllRadiologyReports;
using Hospital_ERP_Backend.Application.Features.RadiologyReports.Queries.GetRadiologyReport;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Extensions
{
    public static class RadiologyReportsServicesExtension
    {
        public static IServiceCollection AddRadiologyReportsServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllRadiologyReportsRequest>, GetAllRadiologyReportsValidator>();
            services.AddScoped<IValidator<GetRadiologyReportRequest>, GetRadiologyReportValidator>();
            services.AddScoped<IValidator<CreateRadiologyReportRequest>, CreateRadiologyReportValidator>();
            services.AddScoped<IValidator<UpdateRadiologyReportRequest>, UpdateRadiologyReportValidator>();
            services.AddScoped<IValidator<DeleteRadiologyReportRequest>, DeleteRadiologyReportValidator>();


            services.AddScoped<GetAllRadiologyReportsService>();
            services.AddScoped<GetRadiologyReportService>();
            services.AddScoped<CreateRadiologyReportService>();
            services.AddScoped<UpdateRadiologyReportService>();
            services.AddScoped<DeleteRadiologyReportService>();

            return services;
        }
    }
}
