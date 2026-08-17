using Hospital_ERP_Backend.Infrastructure.Setting;

namespace Hospital_ERP_Backend.API.Extensions.Configuration
{
    public static class SettingConfigurationExtension
    {
        public static IServiceCollection AddSettingConfiguration(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.Configure<MySetting>(
               Configuration.GetSection("MySettings"));
            return Services;
        }
    }
}
