using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Queries.GetAdministrativeStaff
{
    internal class GetAdministrativeStaffService :
        IRequestHandler<GetAdministrativeStaffRequest, GetAdministrativeStaffResponse>
    {
        private readonly IBaseQueryRepository<AdministrativeStaff> _repository;
        private readonly IValidator<GetAdministrativeStaffRequest> _validator;

        public GetAdministrativeStaffService(
            IBaseQueryRepository<AdministrativeStaff> repository,
            IValidator<GetAdministrativeStaffRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetAdministrativeStaffResponse> Handle(
            GetAdministrativeStaffRequest request,
            CancellationToken cancellationToken)
        {
            return await GetAdministrativeStaffAsync(request);
        }

        private async Task<GetAdministrativeStaffResponse> GetAdministrativeStaffAsync(
            GetAdministrativeStaffRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    $"Invalid request: {string.Join(", ",
                        validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var administrativeStaff = await _repository.GetAsync(request.Id);

            if (administrativeStaff == null)
            {
                throw new KeyNotFoundException(
                    $"Administrative Staff with Id {request.Id} not found.");
            }

            return new GetAdministrativeStaffResponse
            {
                Id = administrativeStaff.Id,
                PersonId = administrativeStaff.PersonId,
                DepartmentId = administrativeStaff.DepartmentId,
                JobTitle = administrativeStaff.JobTitle,
            };
        }
    }
}