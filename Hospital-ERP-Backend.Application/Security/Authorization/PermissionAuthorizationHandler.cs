using Microsoft.AspNetCore.Authorization;

namespace Hospital_ERP_Backend.Application.Security.Authorization;

public sealed class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
        PermissionRequirement requirement)
    {
        var claimType =PermissionClaimTypes.GetClaimType(requirement.PermissionType);

        var claim = context.User.FindFirst(claimType);

        if (claim is null)
        {
            return Task.CompletedTask;
        }

        if (!ulong.TryParse(claim.Value,out var userPermissionMask))
        {
            return Task.CompletedTask;
        }

        var hasPermission = (userPermissionMask & requirement.Permission) == requirement.Permission;

        if (hasPermission)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}