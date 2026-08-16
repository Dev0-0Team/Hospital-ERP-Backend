
using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Permissions.Commands.CreatePermission;
using Hospital_ERP_Backend.Application.Features.Permissions.Commands.DeletePermission;
using Hospital_ERP_Backend.Application.Features.Permissions.Commands.UpdatePermission;
using Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetAllPermissions;
using Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetAllPermissionsOfUser;
using Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetPermission;
using Microsoft.Extensions.DependencyInjection;


namespace Hospital_ERP_Backend.Application.Features.Permissions.Extensions
{
    public static class PermissionServiceExtensions
    {
        public static IServiceCollection AddPermissionServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreatePermissionRequest>, CreatePermissionValidator>();
            services.AddScoped<IValidator<UpdatePermissionRequest>, UpdatePermissionValidator>();
            services.AddScoped<IValidator<DeletePermissionRequest>, DeletePermissionValidator>();
            services.AddScoped<IValidator<GetPermissionRequest>, GetPermissionValidator>();
            services.AddScoped<IValidator<GetAllPermissionsRequest>, GetAllPermissionsValidator>();
            services.AddScoped<IValidator<GetAllPermissionsOfUserRequest>, GetAllPermissionsOfUserValidator>();

            services.AddScoped<CreatePermissionService>();
            services.AddScoped<UpdatePermissionService>();
            services.AddScoped<DeletePermissionService>();
            services.AddScoped<GetPermissionService>();
            services.AddScoped<GetAllPermissionsService>();
            services.AddScoped<GetAllPermissionsOfUserService>();
            return services;
        }
    }
}
