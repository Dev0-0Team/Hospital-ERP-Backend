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
    public class RoomTypeQueryRepository : IBaseQueryRepository<RoomType>
    {
        private readonly MySetting _setting;
        private readonly IDbConnection _connection;

        public RoomTypeQueryRepository(IOptions<MySetting> setting, HospitalDbContext hospitalDbContext)
        {
            _setting = setting.Value;
            _connection = hospitalDbContext.Database.GetDbConnection();
        }

        public async Task<RoomType?> GetAsync(int id)
        {
            var parameters = new
            {
                id = id
            };
            var query = "room_types.SP_GetRoomTypeById";
            return await _connection.QueryFirstOrDefaultAsync<RoomType>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<RoomType>> GetAllAsync(int page)
        {
            var parameters = new
            {
                page,
                rows = _setting.RowsPerPage
            };
            var query = "room_types.SP_GetAllRoomTypes";
            return await _connection.QueryAsync<RoomType>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}