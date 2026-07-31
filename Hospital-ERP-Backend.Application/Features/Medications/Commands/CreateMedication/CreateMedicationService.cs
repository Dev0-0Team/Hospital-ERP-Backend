using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Medications.Commands.CreateMedication
{
    internal class CreateMedicationService : IRequestHandler<CreateMedicationRequest, CreateMedicationResponse>
    {
        private readonly IBaseCommandRepository<Medication> _medicationRepository;

        private readonly IValidator<CreateMedicationRequest> _validator;
        public CreateMedicationService(IBaseCommandRepository<Medication> medicationRepository, IValidator<CreateMedicationRequest> validator)
        {
            _medicationRepository = medicationRepository;
            _validator = validator;
        }

        public async Task<CreateMedicationResponse> Handle(CreateMedicationRequest request, CancellationToken cancellationToken)
        {
            return await CreateMedicationAsync(request);
        }

        private async Task<CreateMedicationResponse> CreateMedicationAsync(CreateMedicationRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Medication medication = new()
            {
                Name = request.Name,
                DosageForm = request.DosageForm,
                Manufacturer = request.Manufacturer,

            };

            Medication? result = await _medicationRepository.CreateAsync(medication);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create medication");
            }

            return new CreateMedicationResponse
            {
                Id = result.Id,
                Name = result.Name,
                DosageForm = result.DosageForm,
                Manufacturer = result.Manufacturer
            };
        }
    }
}