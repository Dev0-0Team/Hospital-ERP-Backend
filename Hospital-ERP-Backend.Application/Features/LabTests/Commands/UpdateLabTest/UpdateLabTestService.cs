using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Commands.UpdateLabTest
{
    internal class UpdateLabTestService
        : IRequestHandler<UpdateLabTestRequest, UpdateLabTestResponse>
    {
        private readonly IValidator<UpdateLabTestRequest> _validator;
        private readonly IBaseCommandRepository<LabTest> _labTestRepository;
        private readonly IBaseQueryRepository<LabTest> _labTestQueryRepository;

        public UpdateLabTestService(IValidator<UpdateLabTestRequest> validator, IBaseCommandRepository<LabTest> labTestRepository,
            IBaseQueryRepository<LabTest> labTestQueryRepository)
        {
            _validator = validator;
            _labTestRepository = labTestRepository;
            _labTestQueryRepository = labTestQueryRepository;
        }

        public async Task<UpdateLabTestResponse> Handle(UpdateLabTestRequest request, CancellationToken cancellationToken)
        {
            return await UpdateLabTestAsync(request);
        }

        private async Task<UpdateLabTestResponse> UpdateLabTestAsync(UpdateLabTestRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            LabTest? labTest = await _labTestQueryRepository.GetAsync(request.Id);

            if (labTest == null)
            {
                throw new KeyNotFoundException($"Lab Test with id {request.Id} not found");
            }

            labTest.Name = request.Name;
            labTest.NormalRange = request.NormalRange;
            labTest.UpdatedAt = DateTime.Now;

            var result = await _labTestRepository.UpdateAsync(labTest);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update lab test");
            }

            return new UpdateLabTestResponse
            {
                Id = result.Id,
                Name = result.Name,
                NormalRange = result.NormalRange
            };
        }
    }
}