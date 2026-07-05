using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Medications.Queries.GetAllMedications;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Medications.Queries.GetMedicationById
{
    public class GetMedicationService : IRequestHandler<GetMedicationRequest, GetMedicationResponse>
    {
        private readonly IValidator<GetMedicationRequest> _validator;
        private readonly IBaseQueryRepository<Medication> _medication;

        public GetMedicationService(IValidator<GetMedicationRequest> validator, IBaseQueryRepository<Medication> medication)
        {
            _validator = validator;
            _medication = medication;
        }
        public Task<GetMedicationResponse> Handle(GetMedicationRequest request, CancellationToken cancellationToken)
        {
            return GetMedicationAsync(request);
        }
        private async Task<GetMedicationResponse> GetMedicationAsync(GetMedicationRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var medication = await _medication.GetAsync(request.Id);
            if (medication == null)
            {
                throw new KeyNotFoundException($"No medication found with ID {request.Id}.");
            }
            return new GetMedicationResponse
            {
                Id = medication.Id,
                Name = medication.Name,
                DosageForm = medication.DosageForm,
                Manufacturer = medication.Manufacturer ?? string.Empty
            };
        }

    }
}
