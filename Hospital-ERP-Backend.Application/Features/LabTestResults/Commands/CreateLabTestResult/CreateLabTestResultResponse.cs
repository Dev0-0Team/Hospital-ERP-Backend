namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Commands.CreateLabTestResult
{
    public record CreateLabTestResultResponse
    {
        public int Id { get; set; }

        public int LabOrderId { get; set; }

        public int LabTestId { get; set; }

        public string Result { get; set; } = string.Empty;
    }
}