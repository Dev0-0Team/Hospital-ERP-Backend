using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.DeleteEmergencyCases
{
    public record DeleteEmergencyCasesRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
