namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Queries.GetAllLabTestResults
{
    public record GetAllLabTestResultsResponse
    {
        public int Id { get; set; }

        public int LabOrderId { get; set; }

        public int LabTestId { get; set; }

        public string Result { get; set; } = string.Empty;
    }
}