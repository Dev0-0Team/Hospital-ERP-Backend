using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Queries.GetRadiologyOrder
{
    public class GetRadiologyOrderService
        : IRequestHandler<GetRadiologyOrderRequest,
            GetRadiologyOrderResponse>
    {
        private readonly IBaseQueryRepository<RadiologyOrder> _repository;

        private readonly IValidator<GetRadiologyOrderRequest> _validator;

        public GetRadiologyOrderService(
            IBaseQueryRepository<RadiologyOrder> repository,
            IValidator<GetRadiologyOrderRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetRadiologyOrderResponse> Handle(
            GetRadiologyOrderRequest request,
            CancellationToken cancellationToken)
        {
            return await GetRadiologyOrderAsync(request);
        }

        private async Task<GetRadiologyOrderResponse>
            GetRadiologyOrderAsync(GetRadiologyOrderRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            RadiologyOrder? order =
                await _repository.GetAsync(request.Id);

            if (order == null)
            {
                throw new KeyNotFoundException(
                    $"Radiology Order with Id {request.Id} not found.");
            }

            return new GetRadiologyOrderResponse
            {
                Id = order.Id,
                PatientId = order.PatientId,
                DoctorId = order.DoctorId,
                Type = order.Type,
                Status = order.Status,
                OrderedAt = order.OrderedAt
            };
        }
    }
}