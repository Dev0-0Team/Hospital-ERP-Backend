using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.CreateDrugInteraction
{
    internal class CreateDrugInteractionService : IRequestHandler<CreateDrugInteractionRequest, CreateDrugInteractionResponse>
    {
        private readonly IBaseCommandRepository<DrugInteraction> _repository;
        private readonly IValidator<CreateDrugInteractionRequest> _validator;

        public CreateDrugInteractionService(IBaseCommandRepository<DrugInteraction> repository,
            IValidator<CreateDrugInteractionRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateDrugInteractionResponse> Handle(CreateDrugInteractionRequest request,
            CancellationToken cancellationToken)
        {
            return await CreateDrugInteractionAsync(request);
        }

        private async Task<CreateDrugInteractionResponse> CreateDrugInteractionAsync(CreateDrugInteractionRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            DrugInteraction interaction = new()
            {
                Medication1Id = request.Medication1Id,
                Medication2Id = request.Medication2Id,
                Severity = request.Severity,
                Warning = request.Warning
            };

            DrugInteraction? result = await _repository.CreateAsync(interaction);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Drug Interaction.");
            }

            return new CreateDrugInteractionResponse
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