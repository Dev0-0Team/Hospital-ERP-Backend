using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class PermissionQueryRepository : BaseQueryRepository<Permission>
    {
        protected override string GetAllSpName => "permissions.SP_GetAllPermissions";
        protected override string GetByIdSpName => "permissions.SP_GetPermissionById";
        public PermissionQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}
