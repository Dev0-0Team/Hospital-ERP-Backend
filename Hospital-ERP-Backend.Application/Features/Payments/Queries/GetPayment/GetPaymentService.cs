using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Payments.Queries.GetPayment
{
    public class GetPaymentService : IRequestHandler<GetPaymentRequest, GetPaymentResponse>
    {
            private readonly IBaseQueryRepository<Payment> _repository;
            private readonly IValidator<GetPaymentRequest> _validator;

        public GetPaymentService(IBaseQueryRepository<Payment> repository, IValidator<GetPaymentRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetPaymentResponse> Handle(GetPaymentRequest request, CancellationToken cancellationToken)
        {
            return await GetPaymentAsync(request);
        }

        private async Task<GetPaymentResponse> GetPaymentAsync(GetPaymentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Payment? payment = await _repository.GetAsync(request.Id);
            if (payment == null)
            {
                throw new KeyNotFoundException($"Payment with Id {request.Id} not found.");
            }

            return new GetPaymentResponse
            {
                Id = payment.Id,
                InvoiceId = payment.InvoiceId,
                PaymentMethodId = payment.PaymentMethodId,
                PaidAt = payment.PaidAt,
                Amount = payment.Amount
            };
        }
    }
}
