using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Queries.GetAllPrescriptions
{
    public record GetAllPrescriptionsRequest : IRequest<IEnumerable<GetAllPrescriptionsResponse>>
    {
        public int Page { get; set; }
    }
}