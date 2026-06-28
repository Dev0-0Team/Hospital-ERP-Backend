using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class PermissionQueryRepository : IBaseQueryRepository<Permission>
    {
        private readonly IDbConnection _connection;
        private readonly MySetting _setting;

        public PermissionQueryRepository(HospitalDbContext hospitalDbContext, IOptions<MySetting> setting)
        {
            _connection = hospitalDbContext.Database.GetDbConnection();
            _setting = setting.Value;
        }

        public async Task<Permission?> GetAsync(int id)
        {
            var parameters = new
            {
                id = id
            };
            var query = "permissions.SP_GetPermissionById";
            return await _connection.QueryFirstOrDefaultAsync<Permission>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Permission>> GetAllAsync(int page)
        {
            var parameters = new
            {
                page,
                rows = _setting.RowsPerPage
            };
            var query = "permissions.SP_GetAllPermissions";
            return await _connection.QueryAsync<Permission>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
