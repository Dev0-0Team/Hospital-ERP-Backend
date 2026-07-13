namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Queries.GetPrescriptionItem
{
    public record GetPrescriptionItemResponse
    {
        public int Id { get; set; }

        public int PrescriptionId { get; set; }

        public int MedicationId { get; set; }

        public string Dosage { get; set; } = string.Empty;

        public string Duration { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public string? Instructions { get; set; }
    }
}