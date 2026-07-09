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
    public class QueuePriorityQueryRepository : IBaseQueryRepository<QueuePriority>
    {
        private readonly MySetting _setting;
        private readonly IDbConnection _connection;

        public QueuePriorityQueryRepository(IOptions<MySetting> setting, HospitalDbContext hospitalDbContext)
        {
            _setting = setting.Value;
            _connection = hospitalDbContext.Database.GetDbConnection();
        }

        public async Task<QueuePriority?> GetAsync(int id)
        {
            var parameters = new { id = id };
            var query = "queue_priorities.SP_GetQueuePriorityById";
            return await _connection.QueryFirstOrDefaultAsync<QueuePriority>(
                query, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<QueuePriority>> GetAllAsync(int page)
        {
            var parameters = new { page, rows = _setting.RowsPerPage };
            var query = "queue_priorities.SP_GetAllQueuePriorities";
            return await _connection.QueryAsync<QueuePriority>(
                query, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
