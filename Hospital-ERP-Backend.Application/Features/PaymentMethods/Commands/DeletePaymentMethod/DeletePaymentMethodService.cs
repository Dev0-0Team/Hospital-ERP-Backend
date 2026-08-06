

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.DeletePaymentMethod
{
    internal class DeletePaymentMethodService : IRequestHandler<DeletePaymentMethodRequest, bool>
    {
        private readonly IBaseCommandRepository<PaymentMethod> _repository;
        private readonly IValidator<DeletePaymentMethodRequest> _validator;

        public DeletePaymentMethodService(IBaseCommandRepository<PaymentMethod> repository, IValidator<DeletePaymentMethodRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeletePaymentMethodRequest request, CancellationToken cancellationToken)
        {
            return await DeletePaymentMethodAsync(request);

        }
        private async Task<bool> DeletePaymentMethodAsync(DeletePaymentMethodRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool isFound = await _repository.IsExistAsync(request.Id);

            if (!isFound)
            {
                throw new KeyNotFoundException($"Payment method with Id {request.Id} not found.");
            }

            var isDeleted = await _repository.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete payment method with Id {request.Id}.");
            }
            return isDeleted;
        }
    }
}
