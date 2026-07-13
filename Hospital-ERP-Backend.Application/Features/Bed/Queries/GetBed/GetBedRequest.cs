using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Beds.Queries.GetBed
{
    public record GetBedRequest : IRequest<GetBedResponse>
    {
        public int Id { get; set; }
    }
}