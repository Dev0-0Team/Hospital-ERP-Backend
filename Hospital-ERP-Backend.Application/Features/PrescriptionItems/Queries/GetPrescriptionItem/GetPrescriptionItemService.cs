using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Queries.GetPrescriptionItem
{
    internal class GetPrescriptionItemService : IRequestHandler<GetPrescriptionItemRequest, GetPrescriptionItemResponse>
    {
        private readonly IBaseQueryRepository<PrescriptionItem> _repository;
        private readonly IValidator<GetPrescriptionItemRequest> _validator;

        public GetPrescriptionItemService(IBaseQueryRepository<PrescriptionItem> repository, IValidator<GetPrescriptionItemRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetPrescriptionItemResponse> Handle(GetPrescriptionItemRequest request, CancellationToken cancellationToken)
        {
            return await GetPrescriptionItemAsync(request);
        }

        private async Task<GetPrescriptionItemResponse> GetPrescriptionItemAsync(GetPrescriptionItemRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            PrescriptionItem? item = await _repository.GetAsync(request.Id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Prescription Item with Id {request.Id} not found.");
            }

            return new GetPrescriptionItemResponse
            {
                Id = item.Id,
                PrescriptionId = item.PrescriptionId,
                MedicationId = item.MedicationId,
                Dosage = item.Dosage,
                Duration = item.Duration,
                Quantity = item.Quantity,
                Instructions = item.Instructions
            };
        }
    }
}