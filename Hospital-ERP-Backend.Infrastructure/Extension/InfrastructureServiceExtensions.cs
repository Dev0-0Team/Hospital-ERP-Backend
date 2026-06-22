using Hospital_ERP_Backend.Infrastructure.Data.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Infrastructure.Extension
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureExtension(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddDbContextConfiguration(Configuration);
            return Services;
        }
    }
}
