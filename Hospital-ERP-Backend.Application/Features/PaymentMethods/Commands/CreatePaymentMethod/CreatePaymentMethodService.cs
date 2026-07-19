using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Permissions.Commands.CreatePermission;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using System.Security;

namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.CreatePaymentMethod
{
    public class CreatePaymentMethodService : IRequestHandler<CreatePaymentMethodRequest, CreatePaymentMethodResponse>
    {
        private readonly IBaseCommandRepository<PaymentMethod> _repository;
        private readonly IValidator<CreatePaymentMethodRequest> _validator;

        public CreatePaymentMethodService(IBaseCommandRepository<PaymentMethod> repository, IValidator<CreatePaymentMethodRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreatePaymentMethodResponse> Handle(CreatePaymentMethodRequest request, CancellationToken cancellationToken)
        {
            return await CreatePaymentMethodAsync(request);
        }

        private async Task<CreatePaymentMethodResponse> CreatePaymentMethodAsync(CreatePaymentMethodRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var paymentMethod = new PaymentMethod
            {
                Name = request.Name
            };

            PaymentMethod? result = await _repository.CreateAsync(paymentMethod);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Payment Method.");
            }

            return new CreatePaymentMethodResponse
            {
                Id = result.Id,
                Name = result.Name
            };
        }
    }
}
