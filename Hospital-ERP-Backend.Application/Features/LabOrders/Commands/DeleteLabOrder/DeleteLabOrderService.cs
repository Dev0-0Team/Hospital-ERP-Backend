using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Commands.DeleteLabOrder
{
    public class DeleteLabOrderService : IRequestHandler<DeleteLabOrderRequest, bool>
    {
        private readonly IValidator<DeleteLabOrderRequest> _validator;

        private readonly IBaseCommandRepository<LabOrder> _repository;

        private readonly IBaseQueryRepository<LabOrder> _queryRepository;

        public DeleteLabOrderService(
            IValidator<DeleteLabOrderRequest> validator,
            IBaseCommandRepository<LabOrder> repository,
            IBaseQueryRepository<LabOrder> queryRepository)
        {
            _validator = validator;
            _repository = repository;
            _queryRepository = queryRepository;
        }

        public async Task<bool> Handle(
            DeleteLabOrderRequest request,
            CancellationToken cancellationToken)
        {
            return await DeleteLabOrderAsync(request);
        }

        private async Task<bool> DeleteLabOrderAsync(
            DeleteLabOrderRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            LabOrder? labOrder =
                await _queryRepository.GetAsync(request.Id);

            if (labOrder == null)
            {
                throw new KeyNotFoundException(
                    $"Lab Order with Id {request.Id} not found.");
            }

            bool isDeleted =
                await _repository.DeleteAsync(labOrder.Id);

            if (!isDeleted)
            {
                throw new InvalidOperationException(
                    $"Failed to delete Lab Order with Id {request.Id}.");
            }

            return isDeleted;
        }
    }
}