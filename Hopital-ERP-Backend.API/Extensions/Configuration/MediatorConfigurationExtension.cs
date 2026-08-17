using Hospital_ERP_Backend.Application.Extensions;

namespace Hospital_ERP_Backend.API.Extensions.Configuration
{
    public static class MediatorConfigurationExtension
    {
        public static IServiceCollection AddMediatorConfigurationExtension(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceExtensions).Assembly);
            });
            return services;
        }
    }
}
