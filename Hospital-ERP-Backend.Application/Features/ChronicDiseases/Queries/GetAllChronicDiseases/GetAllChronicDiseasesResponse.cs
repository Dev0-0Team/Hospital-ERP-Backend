namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Queries.GetAllChronicDiseases
{
    public record GetAllChronicDiseasesResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string DiseaseName { get; set; } = null!;
    }
}
