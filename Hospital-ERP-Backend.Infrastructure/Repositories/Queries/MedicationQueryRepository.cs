using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

public class MedicationQueryRepository
    : IBaseQueryRepository<Medication>
{
    private readonly IDbConnection _connection;
    private readonly MySetting _setting;

    public MedicationQueryRepository(HospitalDbContext hospitalDbContext, IOptions<MySetting> setting)
    {
        _connection = hospitalDbContext.Database.GetDbConnection();
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
}