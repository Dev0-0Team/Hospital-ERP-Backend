using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Commands.DeleteInvoiceItem
{
    internal class DeleteInvoiceItemService
        : IRequestHandler<DeleteInvoiceItemRequest, bool>
    {
        private readonly IValidator<DeleteInvoiceItemRequest> _validator;

        private readonly IBaseCommandRepository<InvoiceItem> _repository;


        public DeleteInvoiceItemService(
            IValidator<DeleteInvoiceItemRequest> validator,
            IBaseCommandRepository<InvoiceItem> repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task<bool> Handle(
            DeleteInvoiceItemRequest request,
            CancellationToken cancellationToken)
        {
            return await DeleteInvoiceItemAsync(request);
        }

        private async Task<bool> DeleteInvoiceItemAsync(
            DeleteInvoiceItemRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool invoiceItem =
                await _repository.IsExistAsync(request.Id);

            if (!invoiceItem)
            {
                throw new KeyNotFoundException(
                    $"Invoice Item with Id {request.Id} not found.");
            }

            bool isDeleted =
                await _repository.DeleteAsync(request.Id);

            if (!isDeleted)
            {
                throw new InvalidOperationException(
                    $"Failed to delete Invoice Item with Id {request.Id}.");
            }

            return isDeleted;
        }
    }
}