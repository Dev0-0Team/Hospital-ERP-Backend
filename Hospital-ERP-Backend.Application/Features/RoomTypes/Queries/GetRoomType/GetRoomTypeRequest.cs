using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetRoomType
{
    public record GetRoomTypeRequest : IRequest<GetRoomTypeResponse>
    {
        public int Id { get; set; }
    }
}