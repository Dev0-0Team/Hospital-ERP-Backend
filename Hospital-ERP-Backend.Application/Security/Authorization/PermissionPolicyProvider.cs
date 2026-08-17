using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Application.Security.Authorization;

public sealed class PermissionPolicyProvider : DefaultAuthorizationPolicyProvider
{
    private const string PolicyPrefix = "Permission:";

    public PermissionPolicyProvider(IOptions<AuthorizationOptions> options): base(options)
    { }

    public override Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (!policyName.StartsWith(PolicyPrefix, StringComparison.Ordinal))
        {
            return base.GetPolicyAsync(policyName);
        }

        var parts = policyName.Split(':');

        if (parts.Length != 3)
        {
            return Task.FromResult<AuthorizationPolicy?>(null);
        }

        var permissionTypeName = parts[1];

        if (!ulong.TryParse(parts[2],out var permission))
        {
            return Task.FromResult<AuthorizationPolicy?>(null);
        }

        var permissionType =
            AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly =>
                {
                    try
                    {
                        return assembly.GetTypes();
                    }
                    catch (ReflectionTypeLoadException)
                    {
                        return [];
                    }
                })
                .FirstOrDefault(type => type.IsEnum && type.FullName == permissionTypeName);

        if (permissionType is null)
        {
            return Task.FromResult<AuthorizationPolicy?>(null);
        }

        var policy =
            new AuthorizationPolicyBuilder()
                .AddRequirements(
                    new PermissionRequirement(
                        permissionType,
                        permission))
                .Build();

        return Task.FromResult<AuthorizationPolicy?>(policy);
    }
}