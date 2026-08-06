using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Payments.Commands.DeletePayment
{
    internal class DeletePaymentService : IRequestHandler<DeletePaymentRequest, bool>
    {
        private readonly IBaseCommandRepository<Payment> _repository;
        private readonly IValidator<DeletePaymentRequest> _validator;

        public DeletePaymentService(IBaseCommandRepository<Payment> repository, IValidator<DeletePaymentRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeletePaymentRequest request, CancellationToken cancellationToken)
        {
            return await DeletePaymentAsync(request);

        }
        private async Task<bool> DeletePaymentAsync(DeletePaymentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool isFound = await _repository.IsExistAsync(request.Id);

            if (!isFound)
            {
                throw new KeyNotFoundException($"Payment with Id {request.Id} not found.");
            }

            var isDeleted = await _repository.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete payment with Id {request.Id}.");
            }
            return isDeleted;
        }
    }
}
