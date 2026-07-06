using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Medications.Commands.CreateMedication
{
    public class CreateMedicationRequest : IRequest<CreateMedicationResponse>
    {
        public string Name { get; set; } = string.Empty;

        public string DosageForm { get; set; } = string.Empty;

        public string? Manufacturer { get; set; }
    }
}
