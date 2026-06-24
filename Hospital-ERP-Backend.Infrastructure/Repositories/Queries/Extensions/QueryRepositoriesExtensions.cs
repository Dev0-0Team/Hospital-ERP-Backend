using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Microsoft.Extensions.DependencyInjection;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Extensions
{
    public static class QueryRepositoriesExtensions
    {
        public static IServiceCollection AddQueryRepositoriesExtension(this IServiceCollection Services)
        {
            Services.AddScoped<IBaseQueryRepository<Person>, PersonQueryRepository>();
            return Services;
        }
    }
}
