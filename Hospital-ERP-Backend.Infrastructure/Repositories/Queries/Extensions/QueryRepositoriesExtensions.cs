using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Microsoft.Extensions.DependencyInjection;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Extensions
{
    public static class QueryRepositoriesExtensions
    {
        public static IServiceCollection AddQueryRepositoriesExtension(this IServiceCollection services)
        {
            services.AddScoped<IBaseQueryRepository<Person>, PersonQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Role>, RoleQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Permission>, PermissionQueryRepository>();
            services.AddScoped<IBaseQueryRepository<User>, UserQueryRepository>();
            services.AddScoped<IBaseQueryRepository<UserRole>, UserRoleQueryRepository>();
            return services;
        }
    }
}
