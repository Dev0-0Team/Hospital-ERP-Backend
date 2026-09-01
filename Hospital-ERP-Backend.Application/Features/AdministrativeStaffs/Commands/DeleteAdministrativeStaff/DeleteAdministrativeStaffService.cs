using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.DeleteAdministrativeStaff
{
    internal class DeleteAdministrativeStaffService :
        IRequestHandler<DeleteAdministrativeStaffRequest, bool>
    {
        private readonly IBaseCommandRepository<AdministrativeStaff> _repository;
        private readonly IValidator<DeleteAdministrativeStaffRequest> _validator;
        private readonly ILogger<DeleteAdministrativeStaffService> _logger;

        public DeleteAdministrativeStaffService(
            IBaseCommandRepository<AdministrativeStaff> repository,
            IValidator<DeleteAdministrativeStaffRequest> validator,
            ILogger<DeleteAdministrativeStaffService> logger)
        {
            _repository = repository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<bool> Handle(
            DeleteAdministrativeStaffRequest request,
            CancellationToken cancellationToken)
        {
            return await DeleteAdministrativeStaffAsync(request);
        }

        private async Task<bool> DeleteAdministrativeStaffAsync(
            DeleteAdministrativeStaffRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning(
                    "Validation failed while deleting Administrative Staff {AdministrativeStaffId}",
                    request.Id);

                throw new ArgumentException(
                    $"Invalid request: {string.Join(", ",
                        validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool administrativeStaff =
                await _repository.IsExistAsync(request.Id);

            if (!administrativeStaff)
            {
                _logger.LogWarning(
                    "Administrative Staff {AdministrativeStaffId} not found while deleting",
                    request.Id);

                throw new KeyNotFoundException(
                    $"Administrative Staff with Id {request.Id} not found.");
            }

            var isDeleted = await _repository.DeleteAsync(request.Id);

            if (!isDeleted)
            {
                _logger.LogWarning(
                    "Failed to delete Administrative Staff {AdministrativeStaffId}",
                    request.Id);

                throw new InvalidOperationException(
                    $"Failed to delete Administrative Staff with Id {request.Id}.");
            }

            _logger.LogInformation(
                "Administrative Staff {AdministrativeStaffId} deleted successfully",
                request.Id);

            return isDeleted;
        }
    }
}