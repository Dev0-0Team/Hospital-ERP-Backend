using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Queries.GetDrugInteraction
{
    public class GetDrugInteractionService : IRequestHandler<GetDrugInteractionRequest, GetDrugInteractionResponse>
    {
        private readonly IBaseQueryRepository<DrugInteraction> _repository;

        private readonly IValidator<GetDrugInteractionRequest> _validator;

        public GetDrugInteractionService(IBaseQueryRepository<DrugInteraction> repository,
            IValidator<GetDrugInteractionRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetDrugInteractionResponse> Handle(GetDrugInteractionRequest request,
            CancellationToken cancellationToken)
        {
            return await GetDrugInteractionAsync(request);
        }

        private async Task<GetDrugInteractionResponse> GetDrugInteractionAsync(GetDrugInteractionRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            DrugInteraction? interaction = await _repository.GetAsync(request.Id);

            if (interaction == null)
            {
                throw new KeyNotFoundException($"Drug Interaction with Id {request.Id} not found.");
            }

            return new GetDrugInteractionResponse
            {
                Id = interaction.Id,
                Medication1Id = interaction.Medication1Id,
                Medication2Id = interaction.Medication2Id,
                Severity = interaction.Severity,
                Warning = interaction.Warning
            };
        }
    }
}