using Hospital_ERP_Backend.Infrastructure.Data.Extension;
using Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Extensions;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Infrastructure.Extension
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureExtension(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddDbContextConfiguration(Configuration);
            Services.AddQueryRepositoriesExtension();
            Services.AddCommandRepositoriesExtension();
            return Services;
        }
    }
}
