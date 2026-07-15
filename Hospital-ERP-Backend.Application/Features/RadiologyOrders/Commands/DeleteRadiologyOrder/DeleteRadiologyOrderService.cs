using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.DeleteRadiologyOrder
{
    public class DeleteRadiologyOrderService : IRequestHandler<DeleteRadiologyOrderRequest, bool>
    {
        private readonly IBaseCommandRepository<RadiologyOrder> _repository;
        private readonly IBaseQueryRepository<RadiologyOrder> _queryRepository;
        private readonly IValidator<DeleteRadiologyOrderRequest> _validator;

        public DeleteRadiologyOrderService(IBaseCommandRepository<RadiologyOrder> repository, IBaseQueryRepository<RadiologyOrder> queryRepository,
           IValidator<DeleteRadiologyOrderRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteRadiologyOrderRequest request, CancellationToken cancellationToken)
        {
            return await DeleteRadiologyOrderAsync(request);
        }
        private async Task<bool> DeleteRadiologyOrderAsync(DeleteRadiologyOrderRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            RadiologyOrder? radiologyOrder = await _queryRepository.GetAsync(request.Id);

            if (radiologyOrder == null)
            {
                throw new KeyNotFoundException($"Radiology Order with Id {request.Id} not found.");
            }

            bool isDeleted = await _repository.DeleteAsync(radiologyOrder.Id);

            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete radiology order with Id {request.Id}.");
            }

            return isDeleted;
        }

    }
}
