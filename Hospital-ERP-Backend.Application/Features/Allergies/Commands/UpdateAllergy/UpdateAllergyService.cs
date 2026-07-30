using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Commands.UpdateAllergy
{
    public class UpdateAllergyService :
        IRequestHandler<UpdateAllergyRequest, UpdateAllergyResponse>
    {
        private readonly IBaseCommandRepository<Allergy> _repository;

        private readonly IBaseQueryRepository<Allergy> _queryRepository;

        private readonly IBaseQueryRepository<Patient> _patientRepository;

        private readonly IValidator<UpdateAllergyRequest> _validator;

        public UpdateAllergyService(
            IBaseCommandRepository<Allergy> repository,
            IBaseQueryRepository<Allergy> queryRepository,
            IBaseQueryRepository<Patient> patientRepository,
            IValidator<UpdateAllergyRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _patientRepository = patientRepository;
            _validator = validator;
        }

        public async Task<UpdateAllergyResponse> Handle(
            UpdateAllergyRequest request,
            CancellationToken cancellationToken)
        {
            return await UpdateAllergyAsync(request);
        }

        private async Task<UpdateAllergyResponse> UpdateAllergyAsync(
            UpdateAllergyRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Patient? patient =
                await _patientRepository.GetAsync(request.PatientId);

            if (patient == null)
            {
                throw new KeyNotFoundException(
                    $"Patient with Id {request.PatientId} not found.");
            }

            Allergy? allergy =
                await _queryRepository.GetAsync(request.Id);

            if (allergy == null)
            {
                throw new KeyNotFoundException(
                    $"Allergy with Id {request.Id} not found.");
            }

            allergy.PatientId = request.PatientId;
            allergy.AllergyName = request.AllergyName;
            allergy.Severity = request.Severity.ToString();
            allergy.UpdatedAt = DateTime.UtcNow;

            Allergy? result =
                await _repository.UpdateAsync(allergy);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to update Allergy.");
            }

            return new UpdateAllergyResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                AllergyName = result.AllergyName,
                Severity = result.Severity
            };
        }
    }
}