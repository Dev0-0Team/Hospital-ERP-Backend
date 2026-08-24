using Hospital_ERP_Backend.Application.Security.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Security.Ownership
{
    public class OwnershipPolicyHandler : AuthorizationHandler<OwnershipPolicyRequirement>
    {
        protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        OwnershipPolicyRequirement requirement)
        {
            var userId = context.User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (!int.TryParse(userId, out var currentUserId))
            {
                return Task.CompletedTask;
            }

            if (context.Resource is HttpContext httpContext)
            {
                var routeId = httpContext.Request.RouteValues["id"];

                if (routeId is not null &&
                    int.TryParse(routeId.ToString(), out var resourceId))
                {
                    if (currentUserId == resourceId)
                    {
                        context.Succeed(requirement);
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}