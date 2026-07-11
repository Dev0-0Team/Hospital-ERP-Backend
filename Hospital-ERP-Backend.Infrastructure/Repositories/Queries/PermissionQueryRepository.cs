using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class PermissionQueryRepository : BaseQueryRepository<Permission>
    {
        protected override string GetAllSpName => "permissions.SP_GetAllPermissions";
        protected override string GetByIdSpName => "permissions.SP_GetPermissionById";
        public PermissionQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}
