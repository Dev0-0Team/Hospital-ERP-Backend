using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.CreateRadiologyReport
{
    public class CreateRadiologyReportService
        : IRequestHandler<CreateRadiologyReportRequest,
            CreateRadiologyReportResponse>
    {
        private readonly IBaseCommandRepository<RadiologyReport> _repository;

        private readonly IValidator<CreateRadiologyReportRequest> _validator;

        public CreateRadiologyReportService(
            IBaseCommandRepository<RadiologyReport> repository,
            IValidator<CreateRadiologyReportRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateRadiologyReportResponse> Handle(
            CreateRadiologyReportRequest request,
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

            RadiologyReport report = new()
            {
                RadiologyOrderId = request.RadiologyOrderId,
                Report = request.Report
            };

            var result =
                await _repository.CreateAsync(report);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to create Radiology Report.");
            }

            return new CreateRadiologyReportResponse
            {
                Id = result.Id,
                RadiologyOrderId = result.RadiologyOrderId,
                Report = result.Report
            };
        }
    }
}