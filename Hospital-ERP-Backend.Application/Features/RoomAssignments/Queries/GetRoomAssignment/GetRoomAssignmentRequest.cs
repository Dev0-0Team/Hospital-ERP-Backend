using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Queries.GetRoomAssignment
{
    public record GetRoomAssignmentRequest : IRequest<GetRoomAssignmentResponse>
    {
        public int Id { get; set; }
    }
}