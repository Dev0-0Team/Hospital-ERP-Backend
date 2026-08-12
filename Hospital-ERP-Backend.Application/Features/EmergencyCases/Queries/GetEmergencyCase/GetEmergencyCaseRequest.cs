using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Queries.GetEmergencyCase
{
    public record GetEmergencyCaseRequest : IRequest<GetEmergencyCaseResponse>
    {
        public int Id { get; set; }
    }
}
