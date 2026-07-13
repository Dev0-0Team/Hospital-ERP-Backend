using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Queries.GetPrescription
{
    public record GetPrescriptionRequest : IRequest<GetPrescriptionResponse>
    {
        public int Id { get; set; }
    }
}