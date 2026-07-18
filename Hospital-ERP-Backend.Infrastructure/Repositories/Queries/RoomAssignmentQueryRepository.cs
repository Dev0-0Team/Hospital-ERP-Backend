using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class RoomAssignmentQueryRepository : BaseQueryRepository<RoomAssignment>
    {
        protected override string GetAllSpName => "room_assignments.SP_GetAllRoomAssignments";
        protected override string GetByIdSpName => "room_assignments.SP_GetRoomAssignmentById";

        public RoomAssignmentQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}