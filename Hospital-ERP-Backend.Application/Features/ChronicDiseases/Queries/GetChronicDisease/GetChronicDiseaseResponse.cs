namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Queries.GetChronicDisease
{
    public record GetChronicDiseaseResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string DiseaseName { get; set; } = null!;
    }
}
