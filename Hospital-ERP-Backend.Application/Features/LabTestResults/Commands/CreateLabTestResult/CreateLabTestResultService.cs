using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Commands.CreateLabTestResult
{
    public class CreateLabTestResultService
        : IRequestHandler<CreateLabTestResultRequest, CreateLabTestResultResponse>
    {
        private readonly IBaseCommandRepository<LabTestResult> _repository;
        private readonly IValidator<CreateLabTestResultRequest> _validator;

        public CreateLabTestResultService(
            IBaseCommandRepository<LabTestResult> repository,
            IValidator<CreateLabTestResultRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateLabTestResultResponse> Handle(
            CreateLabTestResultRequest request,
            CancellationToken cancellationToken)
        {
            return await CreateLabTestResultAsync(request);
        }

        private async Task<CreateLabTestResultResponse> CreateLabTestResultAsync(
            CreateLabTestResultRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            LabTestResult entity = new()
            {
                LabOrderId = request.LabOrderId,
                LabTestId = request.LabTestId,
                Result = request.Result
            };

            var result = await _repository.CreateAsync(entity);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Lab Test Result.");
            }

            return new CreateLabTestResultResponse
            {
                Id = result.Id,
                LabOrderId = result.LabOrderId,
                LabTestId = result.LabTestId,
                Result = result.Result
            };
        }
    }
}