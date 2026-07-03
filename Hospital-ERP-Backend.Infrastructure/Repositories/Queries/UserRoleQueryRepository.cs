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
    public class UserRoleQueryRepository : IBaseQueryRepository<UserRole>
    {
        private readonly MySetting _setting;
        private readonly IDbConnection _connection;

        public UserRoleQueryRepository(IOptions<MySetting> setting, HospitalDbContext hospitalDbContext)
        {
            _setting = setting.Value;
            _connection = hospitalDbContext.Database.GetDbConnection();
        }

        public async Task<UserRole?> GetAsync(int id)
        {
            var parameters = new
            {
                id = id
            };
            var query = "user_roles.SP_GetUserRolesById";
            return await _connection.QueryFirstOrDefaultAsync<UserRole>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync(int page)
        {
            var parameters = new
            {
                page,
                rows = _setting.RowsPerPage
            };
            var query = "user_roles.SP_GetAllUserRoles";
            return await _connection.QueryAsync<UserRole>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
