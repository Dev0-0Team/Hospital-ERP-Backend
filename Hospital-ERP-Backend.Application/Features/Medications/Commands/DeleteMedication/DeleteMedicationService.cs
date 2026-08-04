using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Medications.Commands.DeleteMedication
{
    internal class DeleteMedicationService : IRequestHandler<DeleteMedicationRequest, bool>
    {
        private readonly IValidator<DeleteMedicationRequest> _validator;
        private readonly IBaseCommandRepository<Medication> _medicationRepository;
        public DeleteMedicationService(IValidator<DeleteMedicationRequest> validator, IBaseCommandRepository<Medication> medicationRepository)
        {
            _validator = validator;
            _medicationRepository = medicationRepository;
        }

        public async Task<bool> Handle(DeleteMedicationRequest request, CancellationToken cancellationToken)
        {
            return await DeleteMedicationAsync(request);
        }

        private async Task<bool> DeleteMedicationAsync(DeleteMedicationRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool medication = await _medicationRepository.IsExistAsync(request.Id);

            if (!medication)
            {
                throw new KeyNotFoundException($"Medication with Id {request.Id} not found.");
            }

            var isDeleted = await _medicationRepository.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete medication with Id {request.Id}.");
            }

            return isDeleted;
        }
    }
}
