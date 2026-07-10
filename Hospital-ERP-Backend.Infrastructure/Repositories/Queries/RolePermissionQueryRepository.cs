using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class RolePermissionQueryRepository : IBaseQueryRepository<RolePermission>, IDisposable
    {
        private readonly MySetting _setting;
        private readonly IDbConnection _connection;

        public RolePermissionQueryRepository(IOptions<MySetting> setting)
        {
            _setting = setting.Value;
            _connection = new SqlConnection(_setting.ConnectionString);
        }

        public async Task<RolePermission?> GetAsync(int id)
        {
            var parameters = new
            {
                id = id
            };
            var query = "role_permissions.SP_GetRolePermissionsById";
            return await _connection.QueryFirstOrDefaultAsync<RolePermission>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<RolePermission>> GetAllAsync(int page)
        {
            var parameters = new
            {
                page,
                rows = _setting.RowsPerPage
            };
            var query = "role_permissions.SP_GetAllRolePermissions";
            return await _connection.QueryAsync<RolePermission>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public void Dispose()
        { 
            _connection?.Dispose();
        }
    }
}
