using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.DeletePrescription
{
    public record DeletePrescriptionRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}