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

        private readonly IBaseQueryRepository<InvoiceItem> _queryRepository;

        public DeleteInvoiceItemService(
            IValidator<DeleteInvoiceItemRequest> validator,
            IBaseCommandRepository<InvoiceItem> repository,
            IBaseQueryRepository<InvoiceItem> queryRepository)
        {
            _validator = validator;
            _repository = repository;
            _queryRepository = queryRepository;
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

            InvoiceItem? invoiceItem =
                await _queryRepository.GetAsync(request.Id);

            if (invoiceItem == null)
            {
                throw new KeyNotFoundException(
                    $"Invoice Item with Id {request.Id} not found.");
            }

            bool isDeleted =
                await _repository.DeleteAsync(invoiceItem.Id);

            if (!isDeleted)
            {
                throw new InvalidOperationException(
                    $"Failed to delete Invoice Item with Id {request.Id}.");
            }

            return isDeleted;
        }
    }
}