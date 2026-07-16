using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Specializations.Queries.GetAllSpecializations
{
    public record GetAllSpecializationsRequest : IRequest<IEnumerable<GetAllSpecializationResponse>>
    {
        public int Page { get; set; }
    }
}
