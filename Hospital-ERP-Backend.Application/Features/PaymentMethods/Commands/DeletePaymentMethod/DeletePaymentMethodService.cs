

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
        private readonly IBaseQueryRepository<PaymentMethod> _queryRepository;

        public DeletePaymentMethodService(IBaseCommandRepository<PaymentMethod> repository, IValidator<DeletePaymentMethodRequest> validator, IBaseQueryRepository<PaymentMethod> queryRepository)
        {
            _repository = repository;
            _validator = validator;
            _queryRepository = queryRepository;
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

            PaymentMethod? isFound = await _queryRepository.GetAsync(request.Id);

            if (isFound == null)
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
