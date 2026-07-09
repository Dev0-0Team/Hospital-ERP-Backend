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
    public class MedicationInventoryQueryRepository : IBaseQueryRepository<MedicationInventory>
    {
        private readonly IDbConnection _connection;
        private readonly MySetting _setting;

        public MedicationInventoryQueryRepository(HospitalDbContext hospitalDbContext, IOptions<MySetting> setting)
        {
            _connection = hospitalDbContext.Database.GetDbConnection();
            _setting = setting.Value;
        }

        public async Task<MedicationInventory?> GetAsync(int id)
        {
            var parameters = new
            {
                id
            };

            return await _connection.QueryFirstOrDefaultAsync<MedicationInventory>(
                "medication_inventories.SP_GetMedicationInventoryById",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MedicationInventory>> GetAllAsync(int page)
        {
            var parameters = new
            {
                page,
                rows = _setting.RowsPerPage
            };

            return await _connection.QueryAsync<MedicationInventory>(
                "medication_inventories.SP_GetAllMedicationInventories",
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}