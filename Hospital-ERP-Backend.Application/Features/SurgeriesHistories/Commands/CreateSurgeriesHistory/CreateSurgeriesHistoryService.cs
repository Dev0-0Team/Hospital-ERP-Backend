using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.CreateSurgeriesHistory
{
    internal class CreateSurgeriesHistoryService : IRequestHandler<CreateSurgeriesHistoryRequest, CreateSurgeriesHistoryResponse>
    {
        private readonly IBaseCommandRepository<Patient> _patientRepository;
        private readonly IBaseCommandRepository<SurgeriesHistory> _repository;
        private readonly IValidator<CreateSurgeriesHistoryRequest> _validator;

        public CreateSurgeriesHistoryService(IBaseCommandRepository<Patient> patientRepository,
        IBaseCommandRepository<SurgeriesHistory> repository, IValidator<CreateSurgeriesHistoryRequest> validator)
        {
            _patientRepository = patientRepository;
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateSurgeriesHistoryResponse> Handle(CreateSurgeriesHistoryRequest request, CancellationToken cancellationToken)
        {
            return await CreateSurgeriesHistoryAsync(request);
        }

        private async Task<CreateSurgeriesHistoryResponse> CreateSurgeriesHistoryAsync(CreateSurgeriesHistoryRequest request)
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

            SurgeriesHistory surgeriesHistory = new SurgeriesHistory()
            {
                PatientId = request.PatientId,
                SurgeryDate = request.SurgeryDate,
                SurgeryName = request.SurgeryName
            };

            SurgeriesHistory? result = await _repository.CreateAsync(surgeriesHistory);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Surgeries History.");
            }

            return new CreateSurgeriesHistoryResponse
            {
                Id = result.Id,
                PatientId = request.PatientId,
                SurgeryDate = request.SurgeryDate,
                SurgeryName = request.SurgeryName
            };
        }
    }
}