using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.CreateRadiologyOrder
{
    public class CreateRadiologyOrderService
        : IRequestHandler<CreateRadiologyOrderRequest, CreateRadiologyOrderResponse>
    {
        private readonly IBaseCommandRepository<RadiologyOrder> _repository;

        private readonly IValidator<CreateRadiologyOrderRequest> _validator;

        public CreateRadiologyOrderService(
            IBaseCommandRepository<RadiologyOrder> repository,
            IValidator<CreateRadiologyOrderRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateRadiologyOrderResponse> Handle(
            CreateRadiologyOrderRequest request,
            CancellationToken cancellationToken)
        {
            return await CreateRadiologyOrderAsync(request);
        }

        private async Task<CreateRadiologyOrderResponse> CreateRadiologyOrderAsync(
            CreateRadiologyOrderRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            RadiologyOrder order = new()
            {
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                Type = request.Type,
                Status = request.Status,
                OrderedAt = request.OrderedAt
            };

            var result = await _repository.CreateAsync(order);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to create Radiology Order.");
            }

            return new CreateRadiologyOrderResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                DoctorId = result.DoctorId,
                Type = result.Type,
                Status = result.Status,
                OrderedAt = result.OrderedAt
            };
        }
    }
}