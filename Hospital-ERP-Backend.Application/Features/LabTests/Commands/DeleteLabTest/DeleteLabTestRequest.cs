using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Commands.DeleteLabTest
{
    public record DeleteLabTestRequest() : IRequest<bool>
    {
        public int Id { get; set; }
    }
}