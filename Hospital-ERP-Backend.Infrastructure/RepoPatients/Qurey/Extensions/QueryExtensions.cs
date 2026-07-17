using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries;
using Microsoft.Extensions.DependencyInjection;


namespace Hospital_ERP_Backend.Infrastructure.RepoPatients.Extensions
{
    public static class QueryExtensions
    {
        public static IServiceCollection AddQueryRepositoriesExtension(this IServiceCollection services)
        {
            services.AddScoped<IBaseQueryRepository<Patient>, PatientQuery>();
            
            
            return services;
        }
    }
}
