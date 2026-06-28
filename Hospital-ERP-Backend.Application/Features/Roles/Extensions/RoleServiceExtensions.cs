using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Roles.Commands.CreateRole;
using Hospital_ERP_Backend.Application.Features.Roles.Commands.DeleteRole;
using Hospital_ERP_Backend.Application.Features.Roles.Commands.UpdateRole;
using Hospital_ERP_Backend.Application.Features.Roles.Queries.GetAllRoles;
using Hospital_ERP_Backend.Application.Features.Roles.Queries.GetRole;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Roles.Extensions
{
    public static class RoleServiceExtensions
    {
        public static IServiceCollection AddRoleServicesExtension(this IServiceCollection Services)
        {
            Services.AddScoped<IValidator<CreateRoleRequest>, CreateRoleValidator>();
            Services.AddScoped<IValidator<UpdateRoleRequest>, UpdateRoleValidator>();
            Services.AddScoped<IValidator<DeleteRoleRequest>, DeleteRoleValidator>();
            Services.AddScoped<IValidator<GetRoleRequest>, GetRoleValidator>();
            Services.AddScoped<IValidator<GetAllRolesRequest>, GetAllRolesValidator>();

            Services.AddScoped<CreateRoleService>();
            Services.AddScoped<UpdateRoleService>();
            Services.AddScoped<DeleteRoleService>();
            Services.AddScoped<GetRoleService>();
            Services.AddScoped<GetAllRolesService>();
            return Services;
        }
    }
}
