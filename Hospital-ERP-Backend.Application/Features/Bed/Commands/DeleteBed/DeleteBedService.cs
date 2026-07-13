using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Beds.Commands.DeleteBed
{
    public class DeleteBedService : IRequestHandler<DeleteBedRequest, bool>
    {
        private readonly IValidator<DeleteBedRequest> _validator;
        private readonly IBaseCommandRepository<Bed> _iBed;
        private readonly IBaseQueryRepository<Bed> _iBedQuery;

        public DeleteBedService(IValidator<DeleteBedRequest> validator, IBaseCommandRepository<Bed> iBed, IBaseQueryRepository<Bed> iBedQuery)
        {
            _validator = validator;
            _iBed = iBed;
            _iBedQuery = iBedQuery;
        }

        private async Task<bool> DeleteBedAsync(DeleteBedRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var bed = await _iBedQuery.GetAsync(request.Id);
            if (bed == null)
            {
                throw new KeyNotFoundException($"Bed with Id {request.Id} not found.");
            }

            // Soft delete: sets IsDeleted = true and DeletedAt, record stays in the database
            // and is excluded from query results.
            var isDeleted = await _iBed.DeleteAsync(bed.Id);
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