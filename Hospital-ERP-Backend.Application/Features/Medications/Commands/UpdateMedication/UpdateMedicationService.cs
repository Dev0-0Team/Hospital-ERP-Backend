using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Medications.Commands.UpdateMedication
{
    public class UpdateMedicationService : IRequestHandler<UpdateMedicationRequest, UpdateMedicationResponse>
    {
        private readonly IValidator<UpdateMedicationRequest> _validator;
        private readonly IBaseCommandRepository<Medication> _medicationRepository;
        private readonly IBaseQueryRepository<Medication> _medicationQueryRepository;
        public UpdateMedicationService(IValidator<UpdateMedicationRequest> validator, IBaseCommandRepository<Medication> medicationRepository, IBaseQueryRepository<Medication> medicationQueryRepository)
        {
            _validator = validator;
            _medicationRepository = medicationRepository;
            _medicationQueryRepository = medicationQueryRepository;
        }
        public async Task<UpdateMedicationResponse> Handle(UpdateMedicationRequest request, CancellationToken cancellationToken)
        {
            return await UpdateMedicationAsync(request);
        }

        private async Task<UpdateMedicationResponse> UpdateMedicationAsync(UpdateMedicationRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var medication = await _medicationQueryRepository.GetAsync(request.Id);

            if (medication == null)
            {
                throw new KeyNotFoundException($"Medication with Id {request.Id} not found.");
            }

            medication.Name = request.Name;
            medication.DosageForm = request.DosageForm;
            medication.Manufacturer = request.Manufacturer;
            medication.UpdatedAt = DateTime.UtcNow;

            Medication? result = await _medicationRepository.UpdateAsync(medication);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update Medication.");
            }


            return new UpdateMedicationResponse
            {
                Id = result.Id,
                Name = result.Name,
                DosageForm = result.DosageForm,
                Manufacturer = result.Manufacturer
            };
        }

    }
}
