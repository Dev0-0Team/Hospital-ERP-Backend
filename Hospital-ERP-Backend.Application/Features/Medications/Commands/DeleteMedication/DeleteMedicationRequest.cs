using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Medications.Commands.DeleteMedication
{
    public record DeleteMedicationRequest : IRequest<bool>
    {
        public int Id { get; set; }

    }
}
