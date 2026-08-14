

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.UpdateSurgeriesHistory
{
    public class UpdateSurgeriesHistoryService : IRequestHandler<UpdateSurgeriesHistoryRequest, UpdateSurgeriesHistoryResponse>
    {
        private readonly IBaseCommandRepository<Patient> _patientRepository;
        private readonly IBaseCommandRepository<SurgeriesHistory> _repository;
        private readonly IValidator<UpdateSurgeriesHistoryRequest> _validator;

        public UpdateSurgeriesHistoryService(IBaseCommandRepository<Patient> patientRepository,
        IBaseCommandRepository<SurgeriesHistory> repository, IValidator<UpdateSurgeriesHistoryRequest> validator)
        {
            _patientRepository = patientRepository;
            _repository = repository;
            _validator = validator;
        }

        public async Task<UpdateSurgeriesHistoryResponse> Handle(UpdateSurgeriesHistoryRequest request, CancellationToken cancellationToken)
        {
            return await UpdateSurgeriesHistoryAsync(request);
        }

        private async Task<UpdateSurgeriesHistoryResponse> UpdateSurgeriesHistoryAsync(UpdateSurgeriesHistoryRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool patient = await _patientRepository.IsExistAsync(request.PatientId);
            if (!patient)
            {
                throw new KeyNotFoundException($"Patient with Id {request.PatientId} not found.");
            }

            SurgeriesHistory? surgeriesHistory = await _repository.FindAsync(request.Id);
            if (surgeriesHistory == null)
            {
                throw new KeyNotFoundException($"Surgeries History with Id {request.Id} not found.");
            }

            surgeriesHistory.PatientId = request.Id;
            surgeriesHistory.SurgeryName = request.SurgeryName;
            surgeriesHistory.SurgeryDate = request.SurgeryDate;
            surgeriesHistory.UpdatedAt = DateTime.UtcNow;

            SurgeriesHistory? result = await _repository.UpdateAsync(surgeriesHistory);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to Update Surgeries History.");
            }

            return new UpdateSurgeriesHistoryResponse
            {
                Id = result.Id,
                PatientId = request.PatientId,
                SurgeryDate = request.SurgeryDate,
                SurgeryName = request.SurgeryName
            };
        }
    }
}