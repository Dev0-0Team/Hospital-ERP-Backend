using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Queries.GetAllRadiologyReports
{
    internal class GetAllRadiologyReportsService
        : IRequestHandler<GetAllRadiologyReportsRequest,
            IEnumerable<GetAllRadiologyReportsResponse>>
    {
        private readonly IBaseQueryRepository<RadiologyReport> _repository;

        private readonly IValidator<GetAllRadiologyReportsRequest> _validator;

        public GetAllRadiologyReportsService(
            IBaseQueryRepository<RadiologyReport> repository,
            IValidator<GetAllRadiologyReportsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllRadiologyReportsResponse>> Handle(
            GetAllRadiologyReportsRequest request,
            CancellationToken cancellationToken)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var reports =
                await _repository.GetAllAsync(request.Page);

            if (reports == null || !reports.Any())
            {
                throw new KeyNotFoundException(
                    $"No Radiology Reports found on page {request.Page}");
            }

            return reports.Select(x =>
                new GetAllRadiologyReportsResponse
                {
                    Id = x.Id,
                    RadiologyOrderId = x.RadiologyOrderId,
                    Report = x.Report
                });
        }
    }
}