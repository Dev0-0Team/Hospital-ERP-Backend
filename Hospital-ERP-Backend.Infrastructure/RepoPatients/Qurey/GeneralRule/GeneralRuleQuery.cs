using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base
{
    public abstract class GeneralRuleQuery<T> : IBaseQueryRepository<T>, IDisposable
    {
        protected readonly IDbConnection _connection;
        protected readonly MySetting _setting;

        protected GeneralRuleQuery(IOptions<MySetting> setting)
        {
            _setting = setting.Value;
            _connection = new SqlConnection(_setting.ConnectionString);
        }

        protected abstract string GetAllSpName { get; }
        protected abstract string GetByIdSpName { get; }

        public virtual async Task<IEnumerable<T>> GetAllAsync(int page)
        {
            var parameters = new
            {
                page,
                rows = _setting.RowsPerPage
            };
            return await _connection.QueryAsync<T>(
                GetAllSpName,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public virtual async Task<T?> GetAsync(int id)
        {
            var parameters = new
            {
                id = id
            };
            return await _connection.QueryFirstOrDefaultAsync<T>(
                GetByIdSpName,
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
