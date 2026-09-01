using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Queries.GetAllAdministrativeStaffs
{
    internal class GetAllAdministrativeStaffsService :
        IRequestHandler<GetAllAdministrativeStaffsRequest, IEnumerable<GetAllAdministrativeStaffsResponse>>
    {
        private readonly IBaseQueryRepository<AdministrativeStaff> _repository;
        private readonly IValidator<GetAllAdministrativeStaffsRequest> _validator;
        private readonly ILogger<GetAllAdministrativeStaffsService> _logger;

        public GetAllAdministrativeStaffsService(
            IBaseQueryRepository<AdministrativeStaff> repository,
            IValidator<GetAllAdministrativeStaffsRequest> validator,
            ILogger<GetAllAdministrativeStaffsService> logger)
        {
            _repository = repository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<IEnumerable<GetAllAdministrativeStaffsResponse>> Handle(
            GetAllAdministrativeStaffsRequest request,
            CancellationToken cancellationToken)
        {
            return await GetAllAdministrativeStaffsAsync(request);
        }

        private async Task<IEnumerable<GetAllAdministrativeStaffsResponse>> GetAllAdministrativeStaffsAsync(
            GetAllAdministrativeStaffsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning(
                    "Validation failed while getting Administrative Staffs on page {Page}",
                    request.Page);

                throw new ArgumentException(
                    $"Invalid request: {string.Join(", ",
                        validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var administrativeStaffs = await _repository.GetAllAsync(request.Page);

            if (administrativeStaffs == null || !administrativeStaffs.Any())
            {
                _logger.LogWarning(
                    "No Administrative Staffs found on page {Page}",
                    request.Page);

                throw new KeyNotFoundException(
                    $"No administrative staffs found on page {request.Page}.");
            }

            return administrativeStaffs.Select(q => new GetAllAdministrativeStaffsResponse
            {
                Id = q.Id,
                PersonId = q.PersonId,
                DepartmentId = q.DepartmentId,
                jobTitle = q.JobTitle
            });
        }
    }
}