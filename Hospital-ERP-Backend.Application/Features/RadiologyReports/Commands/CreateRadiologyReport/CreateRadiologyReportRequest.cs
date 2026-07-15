using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.CreateRadiologyReport
{
    public record CreateRadiologyReportRequest
        : IRequest<CreateRadiologyReportResponse>
    {
        public int RadiologyOrderId { get; set; }

        public string Report { get; set; } = string.Empty;
    }
}