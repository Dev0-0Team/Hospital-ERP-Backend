using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Payments.Commands.CreatePayment
{
    internal class CreatePaymentService : IRequestHandler<CreatePaymentRequest, CreatePaymentResponse>
    {
        private readonly IBaseCommandRepository<Payment> _repository;
        private readonly IValidator<CreatePaymentRequest> _validator;

        public CreatePaymentService(IBaseCommandRepository<Payment> repository, IValidator<CreatePaymentRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreatePaymentResponse> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
        {
            return await CreatePaymentAsync(request);
        }

        private async Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var payment = new Payment
            {
                InvoiceId = request.InvoiceId,
                PaymentMethodId = request.PaymentMethodId,
                PaidAt = request.PaidAt,
                Amount = request.Amount
            };

            Payment? result = await _repository.CreateAsync(payment);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Payment.");
            }

            return new CreatePaymentResponse
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
