

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Payments.Commands.UpdatePayment
{
    internal class UpdatePaymentService : IRequestHandler<UpdatePaymentRequest, UpdatePaymentResponse>
    {
        private readonly IBaseCommandRepository<Payment> _repository;
        private readonly IBaseQueryRepository<Payment> _queryRepository;
        private readonly IValidator<UpdatePaymentRequest> _validator;

        public UpdatePaymentService(IBaseCommandRepository<Payment> repository, IBaseQueryRepository<Payment> queryRepository, IValidator<UpdatePaymentRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
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

            var payment = await _queryRepository.GetAsync(request.Id);
            if (payment == null)
            {
                throw new KeyNotFoundException($"Payment with Id {request.Id} not found.");
            }

            payment.InvoiceId = request.InvoiceId;
            payment.PaymentMethodId = request.PaymentMethodId;
            payment.Amount = request.Amount;
            payment.PaidAt = request.PaidAt;

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
