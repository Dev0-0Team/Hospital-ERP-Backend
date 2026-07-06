namespace Hospital_ERP_Backend.Application.Features.Medications.Commands.CreateMedication
{
    public record CreateMedicationResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string DosageForm { get; set; } = string.Empty;

        public string? Manufacturer { get; set; }
    }
}
