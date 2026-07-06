
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.CreateRoomType
{
    public record CreateRoomTypeRequest : IRequest<CreateRoomTypeResponse>
    {
        public string Name { get; set; } = null!;
    }
}