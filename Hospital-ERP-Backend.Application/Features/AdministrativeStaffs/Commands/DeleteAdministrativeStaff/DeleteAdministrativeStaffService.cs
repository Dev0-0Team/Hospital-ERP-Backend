using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.DeleteAdministrativeStaff
{
    internal class DeleteAdministrativeStaffService : IRequestHandler<DeleteAdministrativeStaffRequest, bool>
    {
        private readonly IBaseCommandRepository<AdministrativeStaff> _repository;
        private readonly IBaseQueryRepository<AdministrativeStaff> _queryRepository;
        private readonly IValidator<DeleteAdministrativeStaffRequest> _validator;

        public DeleteAdministrativeStaffService(
            IBaseCommandRepository<AdministrativeStaff> repository,
            IBaseQueryRepository<AdministrativeStaff> queryRepository,
            IValidator<DeleteAdministrativeStaffRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
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

            var administrativeStaff = await _queryRepository.GetAsync(request.Id);
            if (administrativeStaff == null)
            {
                throw new KeyNotFoundException($"administrative staff with Id {request.Id} not found.");
            }

            var isDeleted = await _repository.DeleteAsync(administrativeStaff.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete administrative staff with Id {request.Id}.");
            }

            return isDeleted;
        }
        
    }
}