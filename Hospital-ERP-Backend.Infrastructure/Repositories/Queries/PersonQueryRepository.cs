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
    public class PersonQueryRepository : IBaseQueryRepository<Person>
    {
        private readonly MySetting _setting;
        private readonly IDbConnection _connection;

        public PersonQueryRepository(IOptions<MySetting> setting, HospitalDbContext hospitalDbContext)
        {
            _setting = setting.Value;
            _connection = hospitalDbContext.Database.GetDbConnection();
        }

        public async Task<Person?> GetAsync(int id)
        {
            var parameters = new
            {
                id = id
            };
            var query = "persons.SP_GetPersonById";
            return await _connection.QueryFirstOrDefaultAsync<Person>(
                query,
                parameters
            );
        }

        public async Task<IEnumerable<Person>> GetAllAsync(int page)
        {
            var parameters = new
            {
                page,
                rows = _setting.RowsPerPage
            };
            var query = "persons.SP_GetAllPersons";
            return await _connection.QueryAsync<Person>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
