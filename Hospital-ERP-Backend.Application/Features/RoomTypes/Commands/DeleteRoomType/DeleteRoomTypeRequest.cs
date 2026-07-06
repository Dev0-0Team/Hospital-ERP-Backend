using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.DeleteRoomType
{
    public record DeleteRoomTypeRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}