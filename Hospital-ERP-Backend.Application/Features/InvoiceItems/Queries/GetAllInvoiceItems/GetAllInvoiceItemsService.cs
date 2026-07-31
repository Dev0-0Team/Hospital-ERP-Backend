using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Queries.GetAllInvoiceItems
{
    internal class GetAllInvoiceItemsService : IRequestHandler<GetAllInvoiceItemsRequest, IEnumerable<GetAllInvoiceItemsResponse>>
    {
        private readonly IBaseQueryRepository<InvoiceItem> _repository;
        private readonly IValidator<GetAllInvoiceItemsRequest> _validator;

        public GetAllInvoiceItemsService(
            IBaseQueryRepository<InvoiceItem> repository,
            IValidator<GetAllInvoiceItemsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllInvoiceItemsResponse>> Handle(
            GetAllInvoiceItemsRequest request,
            CancellationToken cancellationToken)
        {
            return await GetAllInvoiceItemsAsync(request);
        }

        private async Task<IEnumerable<GetAllInvoiceItemsResponse>> GetAllInvoiceItemsAsync(
            GetAllInvoiceItemsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));

            IEnumerable<InvoiceItem> invoiceItems =
                await _repository.GetAllAsync(request.Page);

            if (invoiceItems == null || !invoiceItems.Any())
                throw new KeyNotFoundException($"No Invoice Items found on page {request.Page}.");

            return invoiceItems.Select(x => new GetAllInvoiceItemsResponse
            {
                Id = x.Id,
                InvoiceId = x.InvoiceId,
                ItemName = x.ItemName,
                Amount = x.Amount,
                ReferenceType = x.ReferenceType,
                ReferenceId = x.ReferenceId
            });
        }
    }
}