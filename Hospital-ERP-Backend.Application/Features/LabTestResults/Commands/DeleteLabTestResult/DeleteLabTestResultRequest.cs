using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Commands.DeleteLabTestResult
{
    public record DeleteLabTestResultRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}