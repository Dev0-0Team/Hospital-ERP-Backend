using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Commands.UpdateInvoiceItem
{
    internal class UpdateInvoiceItemService
        : IRequestHandler<UpdateInvoiceItemRequest, UpdateInvoiceItemResponse>
    {
        private readonly IValidator<UpdateInvoiceItemRequest> _validator;

        private readonly IBaseCommandRepository<InvoiceItem> _repository;
        private readonly IBaseCommandRepository<Invoice> _invoiceRepository;

        public UpdateInvoiceItemService(
            IValidator<UpdateInvoiceItemRequest> validator,
            IBaseCommandRepository<InvoiceItem> repository,
            IBaseCommandRepository<Invoice> invoiceRepository)
        {
            _validator = validator;
            _repository = repository;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<UpdateInvoiceItemResponse> Handle(
            UpdateInvoiceItemRequest request,
            CancellationToken cancellationToken)
        {
            return await UpdateInvoiceItemAsync(request);
        }

        private async Task<UpdateInvoiceItemResponse> UpdateInvoiceItemAsync(
            UpdateInvoiceItemRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool isInvoiceExist = await _invoiceRepository.IsExistAsync(request.InvoiceId);
            if (!isInvoiceExist)
            {
                throw new KeyNotFoundException(
                    $"Invoice with Id {request.InvoiceId} not found.");
            }


            InvoiceItem? invoiceItem =
                await _repository.FindAsync(request.Id);

            if (invoiceItem == null)
            {
                throw new KeyNotFoundException(
                    $"Invoice Item with Id {request.Id} not found.");
            }

            invoiceItem.InvoiceId = request.InvoiceId;
            invoiceItem.ItemName = request.ItemName;
            invoiceItem.Amount = request.Amount;
            invoiceItem.ReferenceType = request.ReferenceType;
            invoiceItem.ReferenceId = request.ReferenceId;
            invoiceItem.UpdatedAt = DateTime.UtcNow;

            InvoiceItem? result =
                await _repository.UpdateAsync(invoiceItem);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to update Invoice Item.");
            }

            return new UpdateInvoiceItemResponse
            {
                Id = result.Id,
                InvoiceId = result.InvoiceId,
                ItemName = result.ItemName,
                Amount = result.Amount,
                ReferenceType = result.ReferenceType,
                ReferenceId = result.ReferenceId
            };
        }
    }
}