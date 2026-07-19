using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Permissions.Commands.UpdatePermission;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using Microsoft.Identity.Client;
using System.Security;


namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod
{
    public class UpdatePaymentMethodService : IRequestHandler<UpdatePaymentMethodRequest, UpdatePaymentMethodResponse>
    {
        private readonly IBaseCommandRepository<PaymentMethod> _repository;
        private readonly IBaseQueryRepository<PaymentMethod> _queryRepository;
        private readonly IValidator<UpdatePaymentMethodRequest> _validator;

        public UpdatePaymentMethodService(IBaseCommandRepository<PaymentMethod> repository,IBaseQueryRepository<PaymentMethod> queryRepository ,IValidator<UpdatePaymentMethodRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<UpdatePaymentMethodResponse> Handle(UpdatePaymentMethodRequest request, CancellationToken cancellationToken)
        {
            return await UpdatePaymentMethodAsync(request);
        }

        private async Task<UpdatePaymentMethodResponse> UpdatePaymentMethodAsync(UpdatePaymentMethodRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var paymentMethod = await _queryRepository.GetAsync(request.Id);
            if (paymentMethod == null)
            {
                throw new KeyNotFoundException($"Payment method with Id {request.Id} not found.");
            }

            paymentMethod.Name = request.Name;
            paymentMethod.UpdatedAt = DateTime.UtcNow;

            PaymentMethod? result = await _repository.UpdateAsync(paymentMethod);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update Payment method.");
            }
            return new UpdatePaymentMethodResponse
            {
                Id = result.Id,
                Name = result.Name
            };
        }
    }
}
