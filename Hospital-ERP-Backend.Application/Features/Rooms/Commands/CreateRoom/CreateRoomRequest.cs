using Hospital_ERP_Backend.Application.Features.Roles.Commands.CreateRole;
using Hospital_ERP_Backend.Domain.Enums;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Commands.CreateRoom
{
    public record CreateRoomRequest : IRequest<CreateRoomResponse>
    {
        public int DepartmentId { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public RoomStatus Status { get; set; }
    }
}