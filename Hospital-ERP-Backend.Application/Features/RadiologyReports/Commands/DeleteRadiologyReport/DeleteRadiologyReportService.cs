using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.DeleteRadiologyReport
{
    public class DeleteRadiologyReportService : IRequestHandler<DeleteRadiologyReportRequest, bool>
    {
        private readonly IBaseCommandRepository<RadiologyReport> _repository;

        private readonly IBaseQueryRepository<RadiologyReport> _queryRepository;

        private readonly IValidator<DeleteRadiologyReportRequest> _validator;

        public DeleteRadiologyReportService(
            IBaseCommandRepository<RadiologyReport> repository,
            IBaseQueryRepository<RadiologyReport> queryRepository,
            IValidator<DeleteRadiologyReportRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteRadiologyReportRequest request, CancellationToken cancellationToken)
        {
            return await DeleteRadiologyReportAsync(request);
        }

        private async Task<bool> DeleteRadiologyReportAsync(DeleteRadiologyReportRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            RadiologyReport? report = await _queryRepository.GetAsync(request.Id);

            if (report == null)
            {
                throw new KeyNotFoundException($"Radiology Report with Id {request.Id} not found.");
            }

            var isDeleted = await _repository.DeleteAsync(report.Id);

            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete Radiology Report with Id {request.Id}");
            }

            return isDeleted;
        }
    }
}