using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Queries.GetLabTestResult
{
    public class GetLabTestResultService
        : IRequestHandler<GetLabTestResultRequest, GetLabTestResultResponse>
    {
        private readonly IBaseQueryRepository<LabTestResult> _repository;

        private readonly IValidator<GetLabTestResultRequest> _validator;

        public GetLabTestResultService(
            IBaseQueryRepository<LabTestResult> repository,
            IValidator<GetLabTestResultRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetLabTestResultResponse> Handle(
            GetLabTestResultRequest request,
            CancellationToken cancellationToken)
        {
            return await GetLabTestResultAsync(request);
        }

        private async Task<GetLabTestResultResponse> GetLabTestResultAsync(
            GetLabTestResultRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            LabTestResult? result =
                await _repository.GetAsync(request.Id);

            if (result == null)
            {
                throw new KeyNotFoundException(
                    $"Lab Test Result with Id {request.Id} not found.");
            }

            return new GetLabTestResultResponse
            {
                Id = result.Id,
                LabOrderId = result.LabOrderId,
                LabTestId = result.LabTestId,
                Result = result.Result
            };
        }
    }
}