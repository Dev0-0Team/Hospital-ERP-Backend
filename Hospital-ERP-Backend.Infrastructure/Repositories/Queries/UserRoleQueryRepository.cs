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
    public class UserRoleQueryRepository : BaseQueryRepository<UserRole>
    {
        protected override string GetAllSpName => "user_roles.SP_GetAllUserRoles";
        protected override string GetByIdSpName => "user_roles.SP_GetUserRolesById";

        public UserRoleQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}
