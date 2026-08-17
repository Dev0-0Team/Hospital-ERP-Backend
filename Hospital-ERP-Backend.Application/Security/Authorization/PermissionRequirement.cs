using Microsoft.AspNetCore.Authorization;

namespace Hospital_ERP_Backend.Application.Security.Authorization;

public sealed class PermissionRequirement : IAuthorizationRequirement
{
    public Type PermissionType { get; }

    public ulong Permission { get; }

    public PermissionRequirement(Type permissionType, ulong permission)
    {
        PermissionType = permissionType;
        Permission = permission;
    }
}