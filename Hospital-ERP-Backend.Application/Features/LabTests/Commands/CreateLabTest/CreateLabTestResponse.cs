namespace Hospital_ERP_Backend.Application.Features.LabTests.Commands.CreateLabTest
{
    public record CreateLabTestResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string NormalRange { get; set; } = null!;
    }
}
