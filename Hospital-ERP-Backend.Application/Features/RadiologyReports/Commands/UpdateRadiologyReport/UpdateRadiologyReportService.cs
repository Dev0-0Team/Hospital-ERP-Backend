using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.UpdateRadiologyReport
{
    internal class UpdateRadiologyReportService : IRequestHandler<UpdateRadiologyReportRequest, UpdateRadiologyReportResponse>
    {
        private readonly IBaseCommandRepository<RadiologyReport> _repository;

        private readonly IValidator<UpdateRadiologyReportRequest> _validator;

        public UpdateRadiologyReportService(
            IBaseCommandRepository<RadiologyReport> repository,
            IValidator<UpdateRadiologyReportRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<UpdateRadiologyReportResponse> Handle(UpdateRadiologyReportRequest request, CancellationToken cancellationToken)
        {
            return await UpdateRadiologyReportAsync(request);
        }

        private async Task<UpdateRadiologyReportResponse> UpdateRadiologyReportAsync(UpdateRadiologyReportRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            RadiologyReport? report = await _repository.FindAsync(request.Id);

            if (report == null)
            {
                throw new KeyNotFoundException($"Radiology Report with Id {request.Id} not found.");
            }

            report.RadiologyOrderId = request.RadiologyOrderId;
            report.Report = request.Report;
            report.UpdatedAt = DateTime.UtcNow;

            var result = await _repository.UpdateAsync(report);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update Radiology Report.");
            }

            return new UpdateRadiologyReportResponse
            {
                Id = result.Id,
                RadiologyOrderId = result.RadiologyOrderId,
                Report = result.Report
            };
        }
    }
}