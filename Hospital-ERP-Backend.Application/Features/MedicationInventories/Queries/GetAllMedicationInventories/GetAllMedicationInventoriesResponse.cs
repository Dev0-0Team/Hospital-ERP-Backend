namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Queries.GetAllMedicationInventories
{
    public record GetAllMedicationInventoriesResponse
    {
        public int Id { get; set; }

        public int MedicationId { get; set; }

        public int Quantity { get; set; }

        public DateOnly ExpiryDate { get; set; }
    }
}