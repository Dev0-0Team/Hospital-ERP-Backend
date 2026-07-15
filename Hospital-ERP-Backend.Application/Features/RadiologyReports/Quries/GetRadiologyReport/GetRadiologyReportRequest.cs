using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Queries.GetRadiologyReport
{
    public record GetRadiologyReportRequest
        : IRequest<GetRadiologyReportResponse>
    {
        public int Id { get; set; }
    }
}