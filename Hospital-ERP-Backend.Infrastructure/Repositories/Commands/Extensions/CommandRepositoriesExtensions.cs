using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Microsoft.Extensions.DependencyInjection;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Extensions
{
    public static class CommandRepositoriesExtensions
    {
        public static IServiceCollection AddCommandRepositoriesExtension(this IServiceCollection services)
        {
            services.AddScoped<IBaseCommandRepository<Person>, PersonCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Role>, RoleCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Permission>, PermissionCommandRepository>();
            services.AddScoped<IBaseCommandRepository<User>, UserCommandRepository>();
            services.AddScoped<IBaseCommandRepository<UserRole>, UserRoleCommandRepository>();
            services.AddScoped<IBaseCommandRepository<RolePermission>, RolePermissionCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Medication>, MedicationCommandRepository>();
            return services;
        }
    }
}
