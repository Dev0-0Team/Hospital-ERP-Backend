using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class RoomQueryRepository : BaseQueryRepository<Room>
    {
        protected override string GetAllSpName => "rooms.SP_GetAllRooms";
        protected override string GetByIdSpName => "rooms.SP_GetRoomById";

        public RoomQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}