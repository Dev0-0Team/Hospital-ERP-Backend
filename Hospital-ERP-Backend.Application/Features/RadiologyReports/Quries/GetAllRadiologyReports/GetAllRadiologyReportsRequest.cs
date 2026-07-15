using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Queries.GetAllRadiologyReports
{
    public record GetAllRadiologyReportsRequest
        : IRequest<IEnumerable<GetAllRadiologyReportsResponse>>
    {
        public int Page { get; set; }
    }
}