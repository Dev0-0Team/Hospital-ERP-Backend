using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Invoices.Commands.DeleteInvoice
{
    public class DeleteInvoiceService : IRequestHandler<DeleteInvoiceRequest, bool>
    {
        private readonly IBaseCommandRepository<Invoice> _repository;
        private readonly IBaseQueryRepository<Invoice> _queryRepository;
        private readonly IValidator<DeleteInvoiceRequest> _validator;

        public DeleteInvoiceService(
            IBaseCommandRepository<Invoice> repository,
            IBaseQueryRepository<Invoice> queryRepository,
            IValidator<DeleteInvoiceRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteInvoiceRequest request, CancellationToken cancellationToken)
        {
            return await DeleteInvoiceAsync(request);
        }

        private async Task<bool> DeleteInvoiceAsync(DeleteInvoiceRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Invoice? invoice = await _queryRepository.GetAsync(request.Id);
            if (invoice == null)
            {
                throw new KeyNotFoundException($"Invoice with Id {request.Id} not found.");
            }

            bool isDeleted = await _repository.DeleteAsync(invoice.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete Invoice with Id {request.Id}.");
            }

            return isDeleted;
        }
    }
}