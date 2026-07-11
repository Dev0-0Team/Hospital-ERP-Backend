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
    public class RoomTypeQueryRepository : BaseQueryRepository<RoomType>
    {
        protected override string GetAllSpName => "room_types.SP_GetAllRoomTypes";
        protected override string GetByIdSpName => "room_types.SP_GetRoomTypeById";

        public RoomTypeQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}