using Hospital_ERP_Backend.Application.Features.Roles.Queries.GetAllRoles;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Queries.GetAllRooms
{
    public record GetAllRoomsRequest : IRequest<IEnumerable<GetAllRoomsResponse>>
    {
        public int Page { get; set; }
    }
}