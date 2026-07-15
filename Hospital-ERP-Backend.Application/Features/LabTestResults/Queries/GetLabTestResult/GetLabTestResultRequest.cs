using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Queries.GetLabTestResult
{
    public record GetLabTestResultRequest : IRequest<GetLabTestResultResponse>
    {
        public int Id { get; set; }
    }
}