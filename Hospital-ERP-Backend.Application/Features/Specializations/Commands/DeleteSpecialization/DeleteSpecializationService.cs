using FluentValidation;
using FluentValidation.Results;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Specializations.Commands.DeleteSpecialization
{
    internal class DeleteSpecializationService : IRequestHandler<DeleteSpecializationRequest, bool>
    {
        private readonly IBaseCommandRepository<Specialization> _repository;
        private readonly IValidator<DeleteSpecializationRequest> _validator;

        public DeleteSpecializationService
            (IBaseCommandRepository<Specialization> repository,
            IValidator<DeleteSpecializationRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteSpecializationRequest request, CancellationToken cancellationToken)
        {
            return await DeleteSpecializationAsync(request);
        }

        private async Task<bool> DeleteSpecializationAsync(DeleteSpecializationRequest request)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool specialization = await _repository.IsExistAsync(request.Id);
            if (!specialization)
            {
                throw new KeyNotFoundException($"Specialization with Id {request.Id} not found.");
            }
            var isDeleted = await _repository.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete Specialization with Id {request.Id}.");
            }
            return isDeleted;
        }
    }
}
