using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Commands.UpdateLabTest
{
    public record UpdateLabTestRequest() : IRequest<UpdateLabTestResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string NormalRange { get; set; } = null!;
    }
}