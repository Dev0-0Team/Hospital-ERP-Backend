using FluentValidation;
using FluentValidation.Results;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Specializations.Commands.CreateSpecialization
{
    public class CreateSpecializationService : IRequestHandler<CreateSpecializationRequest, CreateSpecializationResponse>
    {
        private readonly IBaseCommandRepository<Specialization> _repository;
        private readonly IValidator<CreateSpecializationRequest> _validator;

        public CreateSpecializationService(IBaseCommandRepository<Specialization> repository, IValidator<CreateSpecializationRequest> validator)
        { 
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateSpecializationResponse> Handle(CreateSpecializationRequest request, CancellationToken cancellationToken)
        {
            return await CreateSpecializationAsync(request);
        }

        private async Task<CreateSpecializationResponse> CreateSpecializationAsync(CreateSpecializationRequest request)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Specialization specialization = new Specialization
            {
                Name = request.Name
            };

            Specialization? result = await _repository.CreateAsync(specialization);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Specialization.");
            }

            return new CreateSpecializationResponse()
            {
                Id = result.Id,
                Name = result.Name
            };
        }
    }
}
