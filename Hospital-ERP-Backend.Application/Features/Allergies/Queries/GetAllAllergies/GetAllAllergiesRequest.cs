using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Queries.GetAllAllergies
{
    public record GetAllAllergiesRequest :
        IRequest<IEnumerable<GetAllAllergiesResponse>>
    {
        public int Page { get; set; }
    }
}