using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Beds.Queries.GetAllBeds
{
    public record GetAllBedsRequest : IRequest<IEnumerable<GetAllBedsResponse>>
    {
        public int Page { get; set; }
    }
}