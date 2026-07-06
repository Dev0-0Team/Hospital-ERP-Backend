using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.UpdateRoomType
{
    public record UpdateRoomTypeRequest : IRequest<UpdateRoomTypeResponse>
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
    }
}