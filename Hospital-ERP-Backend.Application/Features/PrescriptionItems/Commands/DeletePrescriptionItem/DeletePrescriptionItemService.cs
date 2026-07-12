using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Commands.DeletePrescriptionItem
{
    public class DeletePrescriptionItemService : IRequestHandler<DeletePrescriptionItemRequest, bool>
    {
        private readonly IValidator<DeletePrescriptionItemRequest> _validator;

        private readonly IBaseCommandRepository<PrescriptionItem> _repository;

        private readonly IBaseQueryRepository<PrescriptionItem> _queryRepository;

        public DeletePrescriptionItemService(
            IValidator<DeletePrescriptionItemRequest> validator,
            IBaseCommandRepository<PrescriptionItem> repository,
            IBaseQueryRepository<PrescriptionItem> queryRepository)
        {
            _validator = validator;
            _repository = repository;
            _queryRepository = queryRepository;
        }

        public async Task<bool> Handle(
            DeletePrescriptionItemRequest request,
            CancellationToken cancellationToken)
        {
            return await DeletePrescriptionItemAsync(request);
        }

        private async Task<bool> DeletePrescriptionItemAsync(
            DeletePrescriptionItemRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            PrescriptionItem? item =
                await _queryRepository.GetAsync(request.Id);

            if (item == null)
            {
                throw new KeyNotFoundException(
                    $"Prescription Item with Id {request.Id} not found.");
            }

            bool isDeleted =
                await _repository.DeleteAsync(item.Id);

            if (!isDeleted)
            {
                throw new InvalidOperationException(
                    $"Failed to delete Prescription Item with Id {request.Id}.");
            }

            return isDeleted;
        }
    }
}