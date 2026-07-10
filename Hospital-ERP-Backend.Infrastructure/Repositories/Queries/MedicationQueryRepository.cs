using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class MedicationQueryRepository
        : IBaseQueryRepository<Medication>, IDisposable
    {
        private readonly IDbConnection _connection;
        private readonly MySetting _setting;

        public MedicationQueryRepository(IOptions<MySetting> setting)
        {
            _connection = new SqlConnection(setting.Value.ConnectionString);
            _setting = setting.Value;
        }

        public async Task<Medication?> GetAsync(int id)
        {
            var parameters = new
            {
                id
            };

            return await _connection.QueryFirstOrDefaultAsync<Medication>(
                "medication.SP_GetMedicationById", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Medication>> GetAllAsync(int page)
        {
            var parameters = new
            {
                page,
                rows = _setting.RowsPerPage
            };

            return await _connection.QueryAsync<Medication>("medication.SP_GetAllMedications",
                parameters, commandType: CommandType.StoredProcedure);
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}