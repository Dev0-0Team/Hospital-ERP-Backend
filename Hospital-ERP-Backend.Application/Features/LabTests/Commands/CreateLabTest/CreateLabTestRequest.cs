using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Commands.CreateLabTest
{
    public class CreateLabTestRequest : IRequest<CreateLabTestResponse>
    {
        public string Name { get; set; } = null!;

        public string NormalRange { get; set; } = null!;
    }
}
