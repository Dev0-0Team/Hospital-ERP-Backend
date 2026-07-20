using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Queries.GetRadiologyReport
{
    public class GetRadiologyReportService
        : IRequestHandler<GetRadiologyReportRequest,
            GetRadiologyReportResponse>
    {
        private readonly IBaseQueryRepository<RadiologyReport> _repository;

        private readonly IValidator<GetRadiologyReportRequest> _validator;

        public GetRadiologyReportService(
            IBaseQueryRepository<RadiologyReport> repository,
            IValidator<GetRadiologyReportRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetRadiologyReportResponse> Handle(
            GetRadiologyReportRequest request,
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

            RadiologyReport? report =
                await _repository.GetAsync(request.Id);

            if (report == null)
            {
                throw new KeyNotFoundException(
                    $"Radiology Report with Id {request.Id} not found.");
            }

            return new GetRadiologyReportResponse
            {
                Id = report.Id,
                RadiologyOrderId = report.RadiologyOrderId,
                Report = report.Report
            };
        }
    }
}