using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Commands.CreateInvoiceItem
{
    internal class CreateInvoiceItemService : IRequestHandler<CreateInvoiceItemRequest, CreateInvoiceItemResponse>
    {
        private readonly IBaseCommandRepository<InvoiceItem> _repository;
        private readonly IBaseCommandRepository<Invoice> _invoiceRepository;
        private readonly IValidator<CreateInvoiceItemRequest> _validator;

        public CreateInvoiceItemService(
            IBaseCommandRepository<InvoiceItem> repository,
            IValidator<CreateInvoiceItemRequest> validator,
            IBaseCommandRepository<Invoice> invoiceRepository)
        {
            _repository = repository;
            _validator = validator;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<CreateInvoiceItemResponse> Handle(
            CreateInvoiceItemRequest request,
            CancellationToken cancellationToken)
        {
            return await CreateInvoiceItemAsync(request);
        }

        private async Task<CreateInvoiceItemResponse> CreateInvoiceItemAsync(
            CreateInvoiceItemRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));

            bool isInvoiceExist = await _invoiceRepository.IsExistAsync(request.InvoiceId);
            if (!isInvoiceExist)
            {
                throw new KeyNotFoundException(
                    $"Invoice Item with Id {request.InvoiceId} not found.");
            }

            InvoiceItem invoiceItem = new()
            {
                InvoiceId = request.InvoiceId,
                ItemName = request.ItemName,
                Amount = request.Amount,
                ReferenceType = request.ReferenceType,
                ReferenceId = request.ReferenceId
            };

            InvoiceItem? result = await _repository.CreateAsync(invoiceItem);

            if (result == null)
                throw new InvalidOperationException("Failed to create Invoice Item.");

            return new CreateInvoiceItemResponse
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