using Hospital_ERP_Backend.Infrastructure.Extension;

namespace Hospital_ERP_Backend.API.Extensions
{
    public static class APIServiceExtensions
    {
        public static IServiceCollection AddAPIServiceExtension(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddInfrastructureExtension(Configuration);
            return Services;
        }
    }
}
