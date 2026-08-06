

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Payments.Commands.UpdatePayment
{
    internal class UpdatePaymentService : IRequestHandler<UpdatePaymentRequest, UpdatePaymentResponse>
    {
        private readonly IBaseCommandRepository<Payment> _repository;
        private readonly IBaseCommandRepository<Invoice> _invoiceRepository;
        private readonly IBaseCommandRepository<PaymentMethod> _paymentMethodRepository;
        private readonly IValidator<UpdatePaymentRequest> _validator;

        public UpdatePaymentService(IBaseCommandRepository<Payment> repository, IValidator<UpdatePaymentRequest> validator ,
         IBaseCommandRepository<Invoice> invoiceRepository, IBaseCommandRepository<PaymentMethod> paymentMethodRepository)
        {
            _repository = repository;
            _validator = validator;
            _paymentMethodRepository = paymentMethodRepository;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<UpdatePaymentResponse> Handle(UpdatePaymentRequest request, CancellationToken cancellationToken)
        {
            return await UpdatePaymentAsync(request);
        }

        private async Task<UpdatePaymentResponse> UpdatePaymentAsync(UpdatePaymentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool isInvoiceExist = await _invoiceRepository.IsExistAsync(request.InvoiceId);
            if (!isInvoiceExist)
            {
                throw new KeyNotFoundException($"Invoice with Id {request.InvoiceId} not found.");
            }

            bool isPaymentMethodExist = await _paymentMethodRepository.IsExistAsync(request.PaymentMethodId);
            if (!isPaymentMethodExist)
            {
                throw new KeyNotFoundException($"Payment method with Id {request.PaymentMethodId} not found.");
            }


            var payment = await _repository.FindAsync(request.Id);
            if (payment == null)
            {
                throw new KeyNotFoundException($"Payment with Id {request.Id} not found.");
            }

            payment.InvoiceId = request.InvoiceId;
            payment.PaymentMethodId = request.PaymentMethodId;
            payment.Amount = request.Amount;
            payment.PaidAt = request.PaidAt;
            payment.UpdatedAt = DateTime.UtcNow;

            Payment? result = await _repository.UpdateAsync(payment);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update Payment.");
            }
            return new UpdatePaymentResponse
            {
                Id = result.Id,
                InvoiceId = result.InvoiceId,
                PaymentMethodId = result.PaymentMethodId,
                PaidAt = result.PaidAt,
                Amount = result.Amount
            };
        }
    }
}
