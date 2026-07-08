namespace Hospital_ERP_Backend.Application.Features.LapTests.Queries.GetAllLabTests
{
    public record GetAllLabTestsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string NormalRange { get; set; } = null!;
    }
}
