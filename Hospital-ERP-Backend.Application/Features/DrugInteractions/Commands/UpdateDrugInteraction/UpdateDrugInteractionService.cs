using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.UpdateDrugInteraction
{
    internal class UpdateDrugInteractionService : IRequestHandler<UpdateDrugInteractionRequest, UpdateDrugInteractionResponse>
    {
        private readonly IBaseCommandRepository<DrugInteraction> _repository;
        private readonly IBaseQueryRepository<DrugInteraction> _queryRepository;
        private readonly IValidator<UpdateDrugInteractionRequest> _validator;

        public UpdateDrugInteractionService(IBaseCommandRepository<DrugInteraction> repository,
            IBaseQueryRepository<DrugInteraction> queryRepository,
            IValidator<UpdateDrugInteractionRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<UpdateDrugInteractionResponse> Handle(UpdateDrugInteractionRequest request,
            CancellationToken cancellationToken)
        {
            return await UpdateDrugInteractionAsync(request);
        }

        private async Task<UpdateDrugInteractionResponse> UpdateDrugInteractionAsync(UpdateDrugInteractionRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            DrugInteraction? interaction = await _queryRepository.GetAsync(request.Id);

            if (interaction == null)
            {
                throw new KeyNotFoundException($"Drug Interaction with Id {request.Id} not found.");
            }

            interaction.Medication1Id = request.Medication1Id;
            interaction.Medication2Id = request.Medication2Id;
            interaction.Severity = request.Severity;
            interaction.Warning = request.Warning;
            interaction.UpdatedAt = DateTime.UtcNow;

            DrugInteraction? result = await _repository.UpdateAsync(interaction);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update Drug Interaction.");
            }

            return new UpdateDrugInteractionResponse
            {
                Id = result.Id,
                Medication1Id = result.Medication1Id,
                Medication2Id = result.Medication2Id,
                Severity = result.Severity,
                Warning = result.Warning
            };
        }
    }
}