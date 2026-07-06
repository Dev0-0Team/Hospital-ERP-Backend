namespace Hospital_ERP_Backend.Application.Features.Medications.Queries.GetAllMedications
{
    public record GetAllMedicationsResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string DosageForm { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;
    }
}