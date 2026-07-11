using Hospital_ERP_Backend.Application.Features.Roles.Commands.CreateRole;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Commands.CreateRoom
{
    public record CreateRoomRequest : IRequest<CreateRoomResponse>
    {
        public int DepartmentId { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}