using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetAllRoomTypes
{
    public record GetAllRoomTypesRequest : IRequest<IEnumerable<GetAllRoomTypesResponse>>
    {
        public int Page { get; set; }
    }
}


