using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Queries.GetAllPrescriptionItems
{
    public class GetAllPrescriptionItemsService : IRequestHandler<GetAllPrescriptionItemsRequest, IEnumerable<GetAllPrescriptionItemsResponse>>
    {
        private readonly IBaseQueryRepository<PrescriptionItem> _repository;
        private readonly IValidator<GetAllPrescriptionItemsRequest> _validator;

        public GetAllPrescriptionItemsService(IBaseQueryRepository<PrescriptionItem> repository, IValidator<GetAllPrescriptionItemsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllPrescriptionItemsResponse>> Handle(GetAllPrescriptionItemsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllPrescriptionItemsAsync(request);
        }

        private async Task<IEnumerable<GetAllPrescriptionItemsResponse>> GetAllPrescriptionItemsAsync(
            GetAllPrescriptionItemsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            IEnumerable<PrescriptionItem> items =
                await _repository.GetAllAsync(request.Page);

            if (items == null || !items.Any())
            {
                throw new KeyNotFoundException(
                    $"No Prescription Items found on page {request.Page}.");
            }

            return items.Select(item => new GetAllPrescriptionItemsResponse
            {
                Id = item.Id,
                PrescriptionId = item.PrescriptionId,
                MedicationId = item.MedicationId,
                Dosage = item.Dosage,
                Duration = item.Duration,
                Quantity = item.Quantity,
                Instructions = item.Instructions
            });
        }
    }
}