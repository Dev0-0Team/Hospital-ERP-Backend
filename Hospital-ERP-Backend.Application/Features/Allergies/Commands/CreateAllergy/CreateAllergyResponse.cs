namespace Hospital_ERP_Backend.Application.Features.Allergies.Commands.CreateAllergy
{
    public record CreateAllergyResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string AllergyName { get; set; } = null!;

        public string Severity { get; set; } = null!;
    }
}