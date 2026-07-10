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
    public class UserQueryRepository : IBaseQueryRepository<User>, IDisposable
    {
        private readonly MySetting _setting;
        private readonly IDbConnection _connection;

        public UserQueryRepository(IOptions<MySetting> setting)
        {
            _setting = setting.Value;
            _connection = new SqlConnection(_setting.ConnectionString);
        }

        public async Task<User?> GetAsync(int id)
        {
            var parameters = new
            {
                id = id
            };
            var query = "users.SP_GetUserById";
            return await _connection.QueryFirstOrDefaultAsync<User>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<User>> GetAllAsync(int page)
        {
            var parameters = new
            {
                page,
                rows = _setting.RowsPerPage
            };
            var query = "users.SP_GetAllUsers";
            return await _connection.QueryAsync<User>(
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
