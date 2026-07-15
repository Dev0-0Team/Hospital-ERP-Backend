using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Queries.GetAllLabTestResults
{
    public record GetAllLabTestResultsRequest : IRequest<IEnumerable<GetAllLabTestResultsResponse>>
    {
        public int Page { get; set; }
    }
}