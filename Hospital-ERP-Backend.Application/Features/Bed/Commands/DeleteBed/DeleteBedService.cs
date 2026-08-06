using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Beds.Commands.DeleteBed
{
    internal class DeleteBedService : IRequestHandler<DeleteBedRequest, bool>
    {
        private readonly IValidator<DeleteBedRequest> _validator;
        private readonly IBaseCommandRepository<Bed> _iBed;

        public DeleteBedService(IValidator<DeleteBedRequest> validator, IBaseCommandRepository<Bed> iBed)
        {
            _validator = validator;
            _iBed = iBed;
        }

        private async Task<bool> DeleteBedAsync(DeleteBedRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool bed = await _iBed.IsExistAsync(request.Id);
            if (!bed)
            {
                throw new KeyNotFoundException($"Bed with Id {request.Id} not found.");
            }

            // Soft delete: sets IsDeleted = true and DeletedAt, record stays in the database
            // and is excluded from query results.
            var isDeleted = await _iBed.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete bed with Id {request.Id}.");
            }
            return isDeleted;
        }

        public async Task<bool> Handle(DeleteBedRequest request, CancellationToken cancellationToken)
        {
            return await DeleteBedAsync(request);
        }
    }
}