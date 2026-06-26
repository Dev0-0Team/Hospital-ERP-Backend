using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Microsoft.Extensions.DependencyInjection;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Extensions
{
    public static class CommandRepositoriesExtensions
    {
        public static IServiceCollection AddCommandRepositoriesExtension(this IServiceCollection Services)
        {
            Services.AddScoped<IBaseCommandRepository<Person>, PersonCommandRepository>();
            Services.AddScoped<IBaseCommandRepository<Role>, RoleCommandRepository>();
            return Services;
        }
    }
}
