using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Commands.DeleteLabTestResult
{
    internal class DeleteLabTestResultService
        : IRequestHandler<DeleteLabTestResultRequest, bool>
    {
        private readonly IBaseCommandRepository<LabTestResult> _repository;
        private readonly IBaseQueryRepository<LabTestResult> _queryRepository;
        private readonly IValidator<DeleteLabTestResultRequest> _validator;

        public DeleteLabTestResultService(
            IBaseCommandRepository<LabTestResult> repository,
            IBaseQueryRepository<LabTestResult> queryRepository,
            IValidator<DeleteLabTestResultRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(
            DeleteLabTestResultRequest request,
            CancellationToken cancellationToken)
        {
            return await DeleteLabTestResultAsync(request);
        }

        private async Task<bool> DeleteLabTestResultAsync(
            DeleteLabTestResultRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var entity = await _queryRepository.GetAsync(request.Id);

            if (entity == null)
            {
                throw new KeyNotFoundException(
                    $"Lab Test Result with Id {request.Id} not found.");
            }

            var deleted = await _repository.DeleteAsync(entity.Id);

            if (!deleted)
            {
                throw new InvalidOperationException(
                    $"Failed to delete Lab Test Result with Id {request.Id}.");
            }

            return deleted;
        }
    }
}