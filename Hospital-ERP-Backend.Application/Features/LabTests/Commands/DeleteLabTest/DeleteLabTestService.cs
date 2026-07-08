using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Commands.DeleteLabTest
{
    public class DeleteLabTestService : IRequestHandler<DeleteLabTestRequest, bool>
    {
        private readonly IBaseCommandRepository<LabTest> _labTestCommandRepo;
        private readonly IBaseQueryRepository<LabTest> _labTestQueryRepo;

        private readonly IValidator<DeleteLabTestRequest> _validator;
        public DeleteLabTestService(IBaseCommandRepository<LabTest> labTestCommandRepo, IBaseQueryRepository<LabTest> labTestQueryRepo, IValidator<DeleteLabTestRequest> validator)
        {
            _labTestCommandRepo = labTestCommandRepo;
            _labTestQueryRepo = labTestQueryRepo;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteLabTestRequest request, CancellationToken cancellationToken)
        {
            return await DeleteLabTestAsync(request);
        }

        private async Task<bool> DeleteLabTestAsync(DeleteLabTestRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            LabTest? labTest = await _labTestQueryRepo.GetAsync(request.Id);
            if (labTest == null)
            {
                throw new ArgumentException($"Lab test with ID {request.Id} not found.");
            }

            var isDeleted = await _labTestCommandRepo.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new ArgumentException($"Failed to delete lab test with ID {request.Id}.");
            }

            return isDeleted;
        }
    }
}