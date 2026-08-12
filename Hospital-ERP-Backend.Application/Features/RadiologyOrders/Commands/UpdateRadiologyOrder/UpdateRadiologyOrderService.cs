using FluentValidation;
using Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.UpdateRadiologyOrder;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.UpdateQueuePriority
{
    internal class UpdateRadiologyOrderService : IRequestHandler<UpdateRadiologyOrderRequest, UpdateRadiologyOrderResponse>
    {
        private readonly IBaseCommandRepository<RadiologyOrder> _repository;
        private readonly IValidator<UpdateRadiologyOrderRequest> _validator;

        public UpdateRadiologyOrderService(IValidator<UpdateRadiologyOrderRequest> validator, IBaseCommandRepository<RadiologyOrder> repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task<UpdateRadiologyOrderResponse> Handle(UpdateRadiologyOrderRequest request, CancellationToken cancellationToken)
        {
            return await UpdateRadiologyOrderAsync(request);
        }


        private async Task<UpdateRadiologyOrderResponse> UpdateRadiologyOrderAsync(UpdateRadiologyOrderRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            RadiologyOrder? order = await _repository.FindAsync(request.Id);
            if (order == null)
            {
                throw new KeyNotFoundException($"Radiology order with Id {request.Id} not found.");
            }


            order.PatientId = request.PatientId;
            order.DoctorId = request.DoctorId;
            order.Type = request.Type;
            order.Status = request.Status;
            order.OrderedAt = request.OrderedAt;
            order.UpdatedAt = DateTime.UtcNow;


            var result = await _repository.UpdateAsync(order);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update radiology order.");
            }

            return new UpdateRadiologyOrderResponse
            {
                Id = request.Id,
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                Type = request.Type,
                Status = request.Status,
                OrderedAt = request.OrderedAt
            };
        }
    }
}