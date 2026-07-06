namespace Hospital_ERP_Backend.Application.Features.Medications.Commands.UpdateMedication
{
    public class UpdateMedicationResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string DosageForm { get; set; } = string.Empty;

        public string? Manufacturer { get; set; }
    }
}