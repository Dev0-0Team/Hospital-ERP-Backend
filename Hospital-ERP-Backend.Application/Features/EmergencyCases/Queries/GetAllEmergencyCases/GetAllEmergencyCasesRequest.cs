using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Queries.GetAllEmergencyCases
{
    public record GetAllEmergencyCasesRequest : IRequest<IEnumerable<GetAllEmergencyCasesResponse>>
    {
        public int Page { get; set; }
    }
}
