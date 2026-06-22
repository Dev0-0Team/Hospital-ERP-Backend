using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Infrastructure.Data.Extension
{
    public static class HospitalDbContextConfigurationExtension
    {
        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection Services, IConfiguration Configuration)
        {
            var setting = Configuration.GetSection("MySettings").Get<MySetting>();
            if (setting == null)
            {
                throw new InvalidOperationException("setting is null");
            }
            Services.AddDbContext<HospitalDbContext>(option => option.UseSqlServer(setting.ConnectionString));
            return Services;
        }
    }
}
