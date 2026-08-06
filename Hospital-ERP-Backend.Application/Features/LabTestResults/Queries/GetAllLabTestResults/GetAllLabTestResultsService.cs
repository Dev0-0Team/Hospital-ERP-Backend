using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Queries.GetAllLabTestResults
{
    internal class GetAllLabTestResultsService : IRequestHandler<GetAllLabTestResultsRequest, IEnumerable<GetAllLabTestResultsResponse>>
    {
        private readonly IBaseQueryRepository<LabTestResult> _repository;

        private readonly IValidator<GetAllLabTestResultsRequest> _validator;

        public GetAllLabTestResultsService(
            IBaseQueryRepository<LabTestResult> repository,
            IValidator<GetAllLabTestResultsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllLabTestResultsResponse>> Handle(
            GetAllLabTestResultsRequest request,
            CancellationToken cancellationToken)
        {
            return await GetAllLabTestResultsAsync(request);
        }

        private async Task<IEnumerable<GetAllLabTestResultsResponse>> GetAllLabTestResultsAsync(
            GetAllLabTestResultsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            IEnumerable<LabTestResult> results =
                await _repository.GetAllAsync(request.Page);

            if (results == null || !results.Any())
            {
                throw new KeyNotFoundException(
                    $"No Lab Test Results found on page {request.Page}.");
            }

            return results.Select(x => new GetAllLabTestResultsResponse
            {
                Id = x.Id,
                LabOrderId = x.LabOrderId,
                LabTestId = x.LabTestId,
                Result = x.Result
            });
        }
    }
}