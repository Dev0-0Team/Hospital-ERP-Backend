using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Queries.GetAllDrugInteractions
{
    public class GetAllDrugInteractionsService : IRequestHandler<GetAllDrugInteractionsRequest,
        IEnumerable<GetAllDrugInteractionsResponse>>
    {
        private readonly IBaseQueryRepository<DrugInteraction> _repository;

        private readonly IValidator<GetAllDrugInteractionsRequest> _validator;

        public GetAllDrugInteractionsService(IBaseQueryRepository<DrugInteraction> repository,
            IValidator<GetAllDrugInteractionsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllDrugInteractionsResponse>> Handle(GetAllDrugInteractionsRequest request,
            CancellationToken cancellationToken)
        {
            return await GetAllDrugInteractionsAsync(request);
        }

        private async Task<IEnumerable<GetAllDrugInteractionsResponse>> GetAllDrugInteractionsAsync(GetAllDrugInteractionsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            IEnumerable<DrugInteraction> interactions = await _repository.GetAllAsync(request.Page);

            if (interactions == null || !interactions.Any())
            {
                throw new KeyNotFoundException($"No Drug Interactions found on page {request.Page}.");
            }

            return interactions.Select(x => new GetAllDrugInteractionsResponse
            {
                Id = x.Id,
                Medication1Id = x.Medication1Id,
                Medication2Id = x.Medication2Id,
                Severity = x.Severity,
                Warning = x.Warning
            });
        }
    }
}