using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LapTests.Queries.GetAllLabTests
{
    public record GetAllLabTestsRequest : IRequest<IEnumerable<GetAllLabTestsResponse>>
    {
        public int Page { get; set; }

    }
}
