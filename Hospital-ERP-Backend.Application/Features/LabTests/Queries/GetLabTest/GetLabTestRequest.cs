using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Queries.GetLabTest
{
    public record GetLabTestRequest : IRequest<GetLabTestResponse>
    {
        public int Id { get; set; }

    }
}
