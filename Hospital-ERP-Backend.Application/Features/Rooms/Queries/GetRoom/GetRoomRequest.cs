using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Queries.GetRoom
{
    public record GetRoomRequest : IRequest<GetRoomResponse>
    {
        public int Id { get; set; }
    }
}