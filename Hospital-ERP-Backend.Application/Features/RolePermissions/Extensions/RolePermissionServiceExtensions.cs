using FluentValidation;
using Hospital_ERP_Backend.Application.Features.RolePermissions.Command.CreateRolePermission;
using Hospital_ERP_Backend.Application.Features.RolePermissions.Command.DeleteRolePermission;
using Hospital_ERP_Backend.Application.Features.RolePermissions.Command.UpdateRolePermission;
using Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetAllRolePermissions;
using Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetRolePermissions;
using Microsoft.Extensions.DependencyInjection;


namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Extensions
{
    public static class RolePermissionServiceExtensions
    {
        public static IServiceCollection AddRolePermmissionServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllRolePermissionsRequest>, GetAllRolePermissionsValidator>();
            services.AddScoped<IValidator<GetRolePermissionsRequest>, GetRolePermissionsValidator>();
            services.AddScoped<IValidator<DeleteRolePermissionRequest>, DeleteRolePermissionValidator>();
            services.AddScoped<IValidator<UpdateRolePermissionRequest>, UpdateRolePermissionValidator>();
            services.AddScoped<IValidator<CreateRolePermissionRequest>, CreateRolePermissionValidator>();

            services.AddScoped<GetAllRolePermissionsService>();
            services.AddScoped<GetRolePermissionsService>();
            services.AddScoped<DeleteRolePermissionService>();
            services.AddScoped<UpdateRolePermissionService>();
            services.AddScoped<CreateRolePermissionService>();
            return services;
        }
    }
}
