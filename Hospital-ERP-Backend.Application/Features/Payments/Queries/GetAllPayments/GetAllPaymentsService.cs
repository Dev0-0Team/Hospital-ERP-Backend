using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Payments.Queries.GetAllPayments
{
    internal class GetAllPaymentsService : IRequestHandler<GetAllPaymentsRequest, IEnumerable<GetAllPaymentsResponse>>
    {
        private readonly IBaseQueryRepository<Payment> _repository;
        private readonly IValidator<GetAllPaymentsRequest> _validator;

        public GetAllPaymentsService(IBaseQueryRepository<Payment> repository, IValidator<GetAllPaymentsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllPaymentsResponse>> Handle(GetAllPaymentsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllPaymentsAsync(request);
        }

        private async Task<IEnumerable<GetAllPaymentsResponse>> GetAllPaymentsAsync(GetAllPaymentsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            IEnumerable<Payment> list = await _repository.GetAllAsync(request.Page);
            if (list == null || list.Count() == 0)
            {
                throw new KeyNotFoundException($"No payment found on page {request.Page}.");
            }

            return list.Select(p => new GetAllPaymentsResponse
            {
                Id = p.Id,
                InvoiceId = p.InvoiceId,
                PaymentMethodId = p.PaymentMethodId,
                PaidAt = p.PaidAt,
                Amount = p.Amount
            });
        }
    }
}
