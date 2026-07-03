using FluentValidation;
using Hospital_ERP_Backend.Application.Features.UserRoles.Commands.CreateUserRole;
using Hospital_ERP_Backend.Application.Features.UserRoles.Commands.DeleteUserRole;
using Hospital_ERP_Backend.Application.Features.UserRoles.Commands.UpdateUserRole;
using Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetAllUserRoles;
using Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetUserRoles;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Extensions
{
    public static class UserRoleServiceExtensions
    {

        public static IServiceCollection AddUserRoleServicesExtension(this IServiceCollection services) 
        {
            services.AddScoped<IValidator<GetAllUserRolesRequest>, GetAllUserRolesValidator>();
            services.AddScoped<IValidator<GetUserRoleRequest>, GetUserRoleValidator>();
            services.AddScoped<IValidator<DeleteUserRoleRequest>, DeleteUserRoleValidator>();
            services.AddScoped<IValidator<UpdateUserRoleRequest>, UpdateUserRoleValidator>();
            services.AddScoped<IValidator<CreateUserRoleRequest>, CreateUserRoleValidator>();

            services.AddScoped<GetAllUserRolesService>();
            services.AddScoped<GetUserRoleService>();
            services.AddScoped<DeleteUserRoleService>();
            services.AddScoped<UpdateUserRoleService>();
            services.AddScoped<CreateUserRoleService>();
            return services;
        }
    }
}
