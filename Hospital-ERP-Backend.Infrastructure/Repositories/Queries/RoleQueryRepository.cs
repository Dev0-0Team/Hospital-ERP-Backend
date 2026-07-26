using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class RoleQueryRepository : BaseQueryRepository<Role>
    {
        protected override string GetAllSpName => "roles.SP_GetAllRoles";
        protected override string GetByIdSpName => "roles.SP_GetRoleById";

        public RoleQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
