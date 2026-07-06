using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Medications.Commands.DeleteMedication
{
    public class DeleteMedicationRequest : IRequest<bool>
    {
        public int Id { get; set; }

    }
}
