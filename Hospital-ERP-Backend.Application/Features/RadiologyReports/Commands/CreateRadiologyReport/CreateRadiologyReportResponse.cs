namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.CreateRadiologyReport
{
    public record CreateRadiologyReportResponse
    {
        public int Id { get; set; }

        public int RadiologyOrderId { get; set; }

        public string Report { get; set; } = string.Empty;
    }
}