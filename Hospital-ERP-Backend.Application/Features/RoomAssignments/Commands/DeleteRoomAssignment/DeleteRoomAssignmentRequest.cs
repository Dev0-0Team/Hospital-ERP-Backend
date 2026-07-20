using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.DeleteRoomAssignment
{
    public record DeleteRoomAssignmentRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}