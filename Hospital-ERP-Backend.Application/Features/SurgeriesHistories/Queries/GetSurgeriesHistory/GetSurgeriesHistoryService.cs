using FluentValidation;
using FluentValidation.Results;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Queries.GetSurgeriesHistory
{
    internal class GetSurgeriesHistoryService : IRequestHandler<GetSurgeriesHistoryRequest, GetSurgeriesHistoryResponse>
    {
        private readonly IBaseQueryRepository<SurgeriesHistory> _repository;
        private readonly IValidator<GetSurgeriesHistoryRequest> _validator;

        public GetSurgeriesHistoryService(IBaseQueryRepository<SurgeriesHistory> repository, IValidator<GetSurgeriesHistoryRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task<GetSurgeriesHistoryResponse> Handle(GetSurgeriesHistoryRequest request, CancellationToken cancellationToken)
        {
            return await GetSurgeriesHistoryAsync(request);
        }

        private async Task<GetSurgeriesHistoryResponse> GetSurgeriesHistoryAsync(GetSurgeriesHistoryRequest request)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            SurgeriesHistory? surgeriesHistory = await _repository.GetAsync(request.Id);
            if (surgeriesHistory == null)
            {
                throw new KeyNotFoundException($"Surgeries History with Id {request.Id} not found.");
            }

            return new GetSurgeriesHistoryResponse
            {
                Id = surgeriesHistory.Id,
                PatientId = surgeriesHistory.PatientId,
                SurgeryName = surgeriesHistory.SurgeryName,
                SurgeryDate = surgeriesHistory.SurgeryDate
            };
        }
    }
}