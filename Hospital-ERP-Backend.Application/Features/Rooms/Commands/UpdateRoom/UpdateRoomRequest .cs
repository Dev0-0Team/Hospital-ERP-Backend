using Hospital_ERP_Backend.Application.Features.Roles.Commands.UpdateRole;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Commands.UpdateRoom
{
    public record UpdateRoomRequest : IRequest<UpdateRoomResponse>
    {
        public int Id { get; init; }
        public int DepartmentId { get; init; }
        public int RoomTypeId { get; init; }
        public string RoomNumber { get; init; } = null!;
        public string Status { get; init; } = null!;
    }
}