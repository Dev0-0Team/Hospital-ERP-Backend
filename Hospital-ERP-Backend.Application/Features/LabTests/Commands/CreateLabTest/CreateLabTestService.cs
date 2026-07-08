using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Commands.CreateLabTest
{
    public class CreateLabTestService : IRequestHandler<CreateLabTestRequest, CreateLabTestResponse>
    {

        private readonly IBaseCommandRepository<LabTest> _labTestCommandRepository;
        private readonly IValidator<CreateLabTestRequest> _validator;

        public CreateLabTestService(IBaseCommandRepository<LabTest> labTestCommandRepository, IValidator<CreateLabTestRequest> validator)
        {
            _labTestCommandRepository = labTestCommandRepository;
            _validator = validator;
        }
        public async Task<CreateLabTestResponse> Handle(CreateLabTestRequest request, CancellationToken cancellationToken)
        {
            return await CreateLabTestAsync(request);
        }

        private async Task<CreateLabTestResponse> CreateLabTestAsync(CreateLabTestRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var labTest = new LabTest
            {
                Name = request.Name,
                NormalRange = request.NormalRange
            };

            LabTest? result = await _labTestCommandRepository.CreateAsync(labTest);

            if (result == null)
            {
                throw new Exception("Failed to create lab test.");
            }

            return new CreateLabTestResponse
            {
                Id = result.Id,
                Name = result.Name,
                NormalRange = result.NormalRange
            };

        }
    }
}