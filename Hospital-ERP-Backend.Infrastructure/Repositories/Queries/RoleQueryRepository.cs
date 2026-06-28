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
    public class RoleQueryRepository : IBaseQueryRepository<Role>
    {
        private readonly MySetting _setting;
        private readonly IDbConnection _connection;

        public RoleQueryRepository(IOptions<MySetting> setting, HospitalDbContext hospitalDbContext)
        {
            _setting = setting.Value;
            _connection = hospitalDbContext.Database.GetDbConnection();
        }

        public async Task<Role?> GetAsync(int id)
        {
            var parameters = new
            {
                id = id
            };
            var query = "roles.SP_GetRoleById";
            return await _connection.QueryFirstOrDefaultAsync<Role>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        } 
        
        public async Task<IEnumerable<Role>> GetAllAsync(int page)
        {
            var parameters = new
            {
                page,
                rows = _setting.RowsPerPage
            };
            var query = "roles.SP_GetAllRoles";
            return await _connection.QueryAsync<Role>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
