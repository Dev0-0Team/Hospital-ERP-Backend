using Hospital_ERP_Backend.Application.Security.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace Hospital_ERP_Backend.API.Extensions
{
    public static class AuthorizationConfigurationExtension
    {
        public static IServiceCollection AddAuthorizationConfigurationExtension(this IServiceCollection service)
        {
            service.AddSingleton<
                IAuthorizationPolicyProvider,PermissionPolicyProvider>();

            service.AddSingleton<
                IAuthorizationHandler,PermissionAuthorizationHandler>();
            return service;
        }
    }
}