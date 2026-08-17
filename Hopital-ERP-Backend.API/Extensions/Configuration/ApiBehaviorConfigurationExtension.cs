using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Extensions.Configuration
{
    public static class ApiBehaviorConfigurationExtension
    {
        public static IServiceCollection AddApiBehaviorConfigurationExtension(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            return services;
        }
    }
}
