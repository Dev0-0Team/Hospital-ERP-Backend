using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.DeleteDrugInteraction
{
    public class DeleteDrugInteractionService : IRequestHandler<DeleteDrugInteractionRequest, bool>
    {
        private readonly IBaseCommandRepository<DrugInteraction> _repository;
        private readonly IBaseQueryRepository<DrugInteraction> _queryRepository;
        private readonly IValidator<DeleteDrugInteractionRequest> _validator;

        public DeleteDrugInteractionService(IBaseCommandRepository<DrugInteraction> repository,
            IBaseQueryRepository<DrugInteraction> queryRepository,
            IValidator<DeleteDrugInteractionRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteDrugInteractionRequest request, CancellationToken cancellationToken)
        {
            return await DeleteDrugInteractionAsync(request);
        }

        private async Task<bool> DeleteDrugInteractionAsync(DeleteDrugInteractionRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            DrugInteraction? interaction = await _queryRepository.GetAsync(request.Id);

            if (interaction == null)
            {
                throw new KeyNotFoundException($"Drug Interaction with Id {request.Id} not found.");
            }

            var success = await _repository.DeleteAsync(interaction.Id);

            if (!success)
            {
                throw new InvalidOperationException($"Failed to delete Drug Interaction with Id {request.Id}.");
            }

            return success;
        }
    }
}