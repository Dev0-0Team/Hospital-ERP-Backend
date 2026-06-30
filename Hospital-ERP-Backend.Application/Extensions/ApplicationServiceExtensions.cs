

using Hospital_ERP_Backend.Application.Features.Permissions.Extensions;
using Hospital_ERP_Backend.Application.Features.Persons.Extensions;
using Hospital_ERP_Backend.Application.Features.Roles.Extensions;
using Hospital_ERP_Backend.Application.Features.Users.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServicesExtension(this IServiceCollection services)
        {
            services.AddPersonServicesExtension();
            services.AddRoleServicesExtension();
            services.AddPermissionServicesExtension();
            services.AddUserServicesExtension();
            return services;
        }
    }
}
