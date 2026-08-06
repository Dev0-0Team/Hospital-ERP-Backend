using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class RoomQueryRepository : BaseQueryRepository<Room>
    {
        protected override string GetAllSpName => "rooms.SP_GetAllRooms";
        protected override string GetByIdSpName => "rooms.SP_GetRoomById";

        public RoomQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}