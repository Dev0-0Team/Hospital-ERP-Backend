

using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetPermission;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using System.Security;

namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Queries.GetPaymentMethod
{
    public class GetPaymentMethodService : IRequestHandler<GetPaymentMethodRequest, GetPaymentMethodResponse>
    {
        private readonly IBaseQueryRepository<PaymentMethod> _repository;
        private readonly IValidator<GetPaymentMethodRequest> _validator;

        public GetPaymentMethodService(IBaseQueryRepository<PaymentMethod> repository, IValidator<GetPaymentMethodRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetPaymentMethodResponse> Handle(GetPaymentMethodRequest request, CancellationToken cancellationToken)
        {
            return await GetPaymentMethodAsync(request);
        }

        private async Task<GetPaymentMethodResponse> GetPaymentMethodAsync(GetPaymentMethodRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            PaymentMethod? paymentMethod = await _repository.GetAsync(request.Id);
            if (paymentMethod == null)
            {
                throw new KeyNotFoundException($"Payment method with Id {request.Id} not found.");
            }

            return new GetPaymentMethodResponse
            {
                Id = paymentMethod.Id,
                Name = paymentMethod.Name
            };
        }

    }
}
