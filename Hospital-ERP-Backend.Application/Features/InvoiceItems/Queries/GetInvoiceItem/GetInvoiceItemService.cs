using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Queries.GetInvoiceItem
{
    public class GetInvoiceItemService : IRequestHandler<GetInvoiceItemRequest, GetInvoiceItemResponse>
    {
        private readonly IBaseQueryRepository<InvoiceItem> _repository;
        private readonly IValidator<GetInvoiceItemRequest> _validator;

        public GetInvoiceItemService(
            IBaseQueryRepository<InvoiceItem> repository,
            IValidator<GetInvoiceItemRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetInvoiceItemResponse> Handle(
            GetInvoiceItemRequest request,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));

            InvoiceItem? invoiceItem = await _repository.GetAsync(request.Id);

            if (invoiceItem == null)
                throw new KeyNotFoundException($"Invoice Item with Id {request.Id} not found.");

            return new GetInvoiceItemResponse
            {
                Id = invoiceItem.Id,
                InvoiceId = invoiceItem.InvoiceId,
                ItemName = invoiceItem.ItemName,
                Amount = invoiceItem.Amount,
                ReferenceType = invoiceItem.ReferenceType,
                ReferenceId = invoiceItem.ReferenceId
            };
        }
    }
}