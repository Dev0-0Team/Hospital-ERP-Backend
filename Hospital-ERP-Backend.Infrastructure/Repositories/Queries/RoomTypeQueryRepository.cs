using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class RoomTypeQueryRepository : BaseQueryRepository<RoomType>
    {
        protected override string GetAllSpName => "room_types.SP_GetAllRoomTypes";
        protected override string GetByIdSpName => "room_types.SP_GetRoomTypeById";

        public RoomTypeQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}