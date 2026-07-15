namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Queries.GetRadiologyReport
{
    public record GetRadiologyReportResponse
    {
        public int Id { get; set; }

        public int RadiologyOrderId { get; set; }

        public string Report { get; set; } = string.Empty;
    }
}