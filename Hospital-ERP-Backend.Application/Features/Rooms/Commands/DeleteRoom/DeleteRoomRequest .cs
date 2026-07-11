using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Commands.DeleteRoom
{
    public record DeleteRoomRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}