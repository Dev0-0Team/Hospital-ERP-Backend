using FluentValidation;
using FluentValidation.Results;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Specializations.Queries.GetSpecialization
{
    internal class GetSpecializationService : IRequestHandler<GetSpecializationRequest, GetSpecializationResponse>
    {
        private readonly IBaseQueryRepository<Specialization> _repository;
        private readonly IValidator<GetSpecializationRequest> _validator;

        public GetSpecializationService(IBaseQueryRepository<Specialization> repository, IValidator<GetSpecializationRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task<GetSpecializationResponse> Handle(GetSpecializationRequest request, CancellationToken cancellationToken)
        {
            return await GetSpecializationAsync(request);
        }

        private async Task<GetSpecializationResponse> GetSpecializationAsync(GetSpecializationRequest request)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Specialization? specialization = await _repository.GetAsync(request.Id);
            if (specialization == null)
            {
                throw new KeyNotFoundException($"Specialization with Id {request.Id} not found.");
            }

            return new GetSpecializationResponse
            {
                Id = specialization.Id,
                Name = specialization.Name
            };
        }
    }
}
