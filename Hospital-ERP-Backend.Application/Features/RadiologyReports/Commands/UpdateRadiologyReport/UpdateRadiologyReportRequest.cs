using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.UpdateRadiologyReport
{
    public record UpdateRadiologyReportRequest : IRequest<UpdateRadiologyReportResponse>
    {
        public int Id { get; set; }

        public int RadiologyOrderId { get; set; }

        public string Report { get; set; } = string.Empty;
    }
}