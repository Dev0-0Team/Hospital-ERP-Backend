using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Security.Ownership.Extension
{
    public static class OwnerShipExtention
    {
        public static IServiceCollection AddOwnershipPolicyExtension(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler,OwnershipPolicyHandler>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Ownership", policy =>
                {
                    policy.Requirements.Add(
                        new OwnershipPolicyRequirement());
                });
            });


            return services;
        }
    }
}
