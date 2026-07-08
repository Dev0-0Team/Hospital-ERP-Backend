namespace Hospital_ERP_Backend.Application.Features.LabTests.Queries.GetLabTest
{
    public record GetLabTestResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string NormalRange { get; set; } = null!;
    }
}
