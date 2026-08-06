using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Commands.CreateAllergy
{
    internal class CreateAllergyService :
        IRequestHandler<CreateAllergyRequest, CreateAllergyResponse>
    {
        private readonly IBaseCommandRepository<Allergy> _repository;

        private readonly IBaseCommandRepository<Patient> _patientRepository;

        private readonly IValidator<CreateAllergyRequest> _validator;

        public CreateAllergyService(
            IBaseCommandRepository<Allergy> repository,
            IBaseCommandRepository<Patient> patientRepository,
            IValidator<CreateAllergyRequest> validator)
        {
            _repository = repository;
            _patientRepository = patientRepository;
            _validator = validator;
        }

        public async Task<CreateAllergyResponse> Handle(CreateAllergyRequest request, CancellationToken cancellationToken)
        {
            return await CreateAllergyAsync(request);
        }

        private async Task<CreateAllergyResponse> CreateAllergyAsync(
            CreateAllergyRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool patient = await _patientRepository.IsExistAsync(request.PatientId);

            if (!patient)
            {
                throw new KeyNotFoundException($"Patient with Id {request.PatientId} not found.");
            }

            Allergy allergy = new()
            {
                PatientId = request.PatientId,
                AllergyName = request.AllergyName,
                Severity = request.Severity.ToString()
            };

            Allergy? result = await _repository.CreateAsync(allergy);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Allergy.");
            }

            return new CreateAllergyResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                AllergyName = result.AllergyName,
                Severity = result.Severity
            };
        }
    }
}