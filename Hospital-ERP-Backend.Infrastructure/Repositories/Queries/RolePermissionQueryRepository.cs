using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class RolePermissionQueryRepository : BaseQueryRepository<RolePermission> 
    {
        protected override string GetAllSpName => "role_permissions.SP_GetAllRolePermissions";
        protected override string GetByIdSpName => "role_permissions.SP_GetRolePermissionsById";

        public RolePermissionQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}
