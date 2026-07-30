namespace Hospital_ERP_Backend.Application.Features.Allergies.Queries.GetAllergy
{
    public record GetAllergyResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string AllergyName { get; set; } = null!;

        public string Severity { get; set; } = null!;
    }
}