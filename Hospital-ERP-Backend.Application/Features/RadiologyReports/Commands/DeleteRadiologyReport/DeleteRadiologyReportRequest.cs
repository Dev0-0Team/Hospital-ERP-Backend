using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.DeleteRadiologyReport
{
    public record DeleteRadiologyReportRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}