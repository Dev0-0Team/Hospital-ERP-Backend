using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Invoices.Queries.GetInvoice
{
    public class GetInvoiceService : IRequestHandler<GetInvoiceRequest, GetInvoiceResponse>
    {
        private readonly IBaseQueryRepository<Invoice> _repository;
        private readonly IValidator<GetInvoiceRequest> _validator;

        public GetInvoiceService(IBaseQueryRepository<Invoice> repository, IValidator<GetInvoiceRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetInvoiceResponse> Handle(GetInvoiceRequest request, CancellationToken cancellationToken)
        {
            return await GetInvoiceAsync(request);
        }

        private async Task<GetInvoiceResponse> GetInvoiceAsync(GetInvoiceRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Invoice? invoice = await _repository.GetAsync(request.Id);
            if (invoice == null)
            {
                throw new KeyNotFoundException($"Invoice with Id {request.Id} not found.");
            }

            return new GetInvoiceResponse
            {
                Id = invoice.Id,
                PatientId = invoice.PatientId,
                TotalAmount = invoice.TotalAmount,
                Status = invoice.Status
            };
        }
    }
}