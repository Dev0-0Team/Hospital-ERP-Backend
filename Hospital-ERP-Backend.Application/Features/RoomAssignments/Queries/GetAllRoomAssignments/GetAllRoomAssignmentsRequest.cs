using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Queries.GetAllRoomAssignments
{
    public record GetAllRoomAssignmentsRequest : IRequest<IEnumerable<GetAllRoomAssignmentsResponse>>
    {
        public int Page { get; set; }
    }
}