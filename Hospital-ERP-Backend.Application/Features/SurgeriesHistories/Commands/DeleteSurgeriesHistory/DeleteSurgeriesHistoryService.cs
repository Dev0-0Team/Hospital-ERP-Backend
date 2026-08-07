
using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.DeleteSurgeriesHistory
{
    public class DeleteSurgeriesHistoryService : IRequestHandler<DeleteSurgeriesHistoryRequest, bool>
    {
        private readonly IBaseCommandRepository<SurgeriesHistory> _repository;
        private readonly IValidator<DeleteSurgeriesHistoryRequest> _validator;

        public DeleteSurgeriesHistoryService(IBaseCommandRepository<SurgeriesHistory> repository, 
        IValidator<DeleteSurgeriesHistoryRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteSurgeriesHistoryRequest request, CancellationToken cancellationToken)
        {
            return await UpdateSurgeriesHistoryAsync(request);
        }

        private async Task<bool> UpdateSurgeriesHistoryAsync(DeleteSurgeriesHistoryRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool surgeriesHistory = await _repository.IsExistAsync(request.Id);
            if (!surgeriesHistory)
            {
                throw new KeyNotFoundException($"Surgeries History with Id {request.Id} not found.");
            }

            bool result = await _repository.DeleteAsync(request.Id);
            if (result)
            {
                throw new InvalidOperationException("Failed to Delete Surgeries History.");
            }

            return result;
        }
    }
} 