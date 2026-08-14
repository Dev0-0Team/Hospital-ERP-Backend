using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Commands.UpdateLabTestResult
{
    internal class UpdateLabTestResultService
        : IRequestHandler<UpdateLabTestResultRequest, UpdateLabTestResultResponse>
    {
        private readonly IBaseCommandRepository<LabTestResult> _repository;
        private readonly IValidator<UpdateLabTestResultRequest> _validator;

        public UpdateLabTestResultService(
            IBaseCommandRepository<LabTestResult> repository,
            IValidator<UpdateLabTestResultRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<UpdateLabTestResultResponse> Handle(
            UpdateLabTestResultRequest request,
            CancellationToken cancellationToken)
        {
            return await UpdateLabTestResultAsync(request);
        }

        private async Task<UpdateLabTestResultResponse> UpdateLabTestResultAsync(
            UpdateLabTestResultRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var entity = await _repository.FindAsync(request.Id);

            if (entity == null)
            {
                throw new KeyNotFoundException(
                    $"Lab Test Result with Id {request.Id} not found.");
            }

            entity.LabOrderId = request.LabOrderId;
            entity.LabTestId = request.LabTestId;
            entity.Result = request.Result;
            entity.UpdatedAt = DateTime.UtcNow;

            var result = await _repository.UpdateAsync(entity);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update Lab Test Result.");
            }

            return new UpdateLabTestResultResponse
            {
                Id = result.Id,
                LabOrderId = result.LabOrderId,
                LabTestId = result.LabTestId,
                Result = result.Result
            };
        }
    }
}