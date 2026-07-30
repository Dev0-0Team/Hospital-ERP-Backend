using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.DeleteAdministrativeStaff
{
    internal class DeleteAdministrativeStaffService : IRequestHandler<DeleteAdministrativeStaffRequest, bool>
    {
        private readonly IBaseCommandRepository<AdministrativeStaff> _repository;
        private readonly IValidator<DeleteAdministrativeStaffRequest> _validator;

        public DeleteAdministrativeStaffService(
            IBaseCommandRepository<AdministrativeStaff> repository,
            IValidator<DeleteAdministrativeStaffRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteAdministrativeStaffRequest request, CancellationToken cancellationToken)
        {
            return await DeleteAdministrativeStaffAsync(request);
        }

        private async Task<bool> DeleteAdministrativeStaffAsync(DeleteAdministrativeStaffRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool administrativeStaff = await _repository.IsExistAsync(request.Id);
            if (!administrativeStaff)
            {
                throw new KeyNotFoundException($"administrative staff with Id {request.Id} not found.");
            }

            var isDeleted = await _repository.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete administrative staff with Id {request.Id}.");
            }

            return isDeleted;
        }
        
    }
}