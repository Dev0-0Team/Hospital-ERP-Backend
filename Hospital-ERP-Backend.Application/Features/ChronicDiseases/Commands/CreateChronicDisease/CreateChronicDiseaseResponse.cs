namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.CreateChronicDisease
{
    public record CreateChronicDiseaseResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string DiseaseName { get; set; } = null!;
    }
}
