using Microsoft.AspNetCore.Authorization;

namespace Hospital_ERP_Backend.Application.Security.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class HasPermissionAttribute<TPermission> : AuthorizeAttribute where TPermission : struct, Enum
{
    private const string PolicyPrefix = "Permission";

    public HasPermissionAttribute(TPermission permission)
    {
        var permissionValue = Convert.ToUInt64(permission);

        Policy = $"{PolicyPrefix}:{typeof(TPermission).FullName}:{permissionValue}";
    }
}