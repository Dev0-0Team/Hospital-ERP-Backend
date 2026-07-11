using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class RoleQueryRepository : BaseQueryRepository<Role>
    {
        protected override string GetAllSpName => "roles.SP_GetAllRoles";
        protected override string GetByIdSpName => "roles.SP_GetRoleById";

        public RoleQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}
