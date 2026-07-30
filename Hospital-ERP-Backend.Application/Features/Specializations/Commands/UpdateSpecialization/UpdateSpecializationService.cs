using FluentValidation;
using FluentValidation.Results;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Specializations.Commands.UpdateSpecialization
{
    internal class UpdateSpecializationService : IRequestHandler<UpdateSpecializationRequest,  UpdateSpecializationResponse>
    {
        private readonly IBaseCommandRepository<Specialization> _repository;
        private readonly IValidator<UpdateSpecializationRequest> _validator;

        public UpdateSpecializationService(IBaseCommandRepository<Specialization> repository, IValidator<UpdateSpecializationRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<UpdateSpecializationResponse> Handle(UpdateSpecializationRequest request, CancellationToken cancellationToken)
        {
            return await UpdateSpecializationAsync(request);
        }

        private async Task<UpdateSpecializationResponse> UpdateSpecializationAsync(UpdateSpecializationRequest request)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Specialization? specialization = await _repository.FindAsync(request.Id);
            if (specialization == null)
            {
                throw new KeyNotFoundException($"Specialization with Id {request.Id} not found.");
            }

            specialization.Name = request.Name;
            specialization.UpdatedAt = DateTime.UtcNow;


            Specialization? result = await _repository.UpdateAsync(specialization);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update specialization.");
            }

            return new UpdateSpecializationResponse
            {
                Id = result.Id,
                Name = result.Name
            };
        }
    }
}
