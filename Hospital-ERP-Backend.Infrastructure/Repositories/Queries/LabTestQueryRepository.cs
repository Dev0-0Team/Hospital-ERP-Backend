using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class LabTestQueryRepository : IBaseQueryRepository<LabTest>, IDisposable
    {
        private readonly IDbConnection _connection;
        private readonly MySetting _setting;

        public LabTestQueryRepository(IOptions<MySetting> mySetting)
        {
            _connection = new SqlConnection(mySetting.Value.ConnectionString);
            this._setting = mySetting.Value;
        }
        public async Task<IEnumerable<LabTest>> GetAllAsync(int page)
        {
            var parameters = new
            {
                Page = page,
                PageSize = _setting.RowsPerPage
            };

            return await _connection.QueryAsync<LabTest>
                ("lab_tests.SP_GetAllLabTests", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<LabTest?> GetAsync(int ID)
        {
            var parameters = new
            {
                ID
            };

            return await _connection.QueryFirstOrDefaultAsync<LabTest>
                ("lab_tests.SP_GetLabTestById", parameters, commandType: CommandType.StoredProcedure);
        }
        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
