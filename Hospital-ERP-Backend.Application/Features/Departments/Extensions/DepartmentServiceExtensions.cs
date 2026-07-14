using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Departments.Commands.CreateDepartment;
using Hospital_ERP_Backend.Application.Features.Departments.Commands.DeleteDepartment;
using Hospital_ERP_Backend.Application.Features.Departments.Commands.UpdateDepartment;
using Hospital_ERP_Backend.Application.Features.Departments.Queries.GetAllDepartments;
using Hospital_ERP_Backend.Application.Features.Departments.Queries.GetDepartment;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Departments.Extensions
{
    public static class DepartmentServiceExtensions
    {
        public static IServiceCollection AddDepartmentServicesExtension(this IServiceCollection services)
        {

            services.AddScoped<IValidator<CreateDepartmentRequest>, CreateDepartmentValidator>();
            services.AddScoped<IValidator<UpdateDepartmentRequest>, UpdateDepartmentValidator>();
            services.AddScoped<IValidator<DeleteDepartmentRequest>, DeleteDepartmentValidator>();
            services.AddScoped<IValidator<GetDepartmentRequest>, GetDepartmentValidator>();
            services.AddScoped<IValidator<GetAllDepartmentsRequest>, GetAllDepartmentsValidator>();


            services.AddScoped<GetDepartmentService>();
            services.AddScoped<GetAllDepartmentsService>();
            services.AddScoped<UpdateDepartmentService>();
            services.AddScoped<DeleteDepartmentService>();
            services.AddScoped<CreateDepartmentService>();
            return services;
        }
    }
}
