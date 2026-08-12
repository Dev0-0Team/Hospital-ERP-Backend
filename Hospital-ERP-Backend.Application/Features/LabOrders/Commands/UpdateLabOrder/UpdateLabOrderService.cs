using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Commands.UpdateLabOrder
{
    internal class UpdateLabOrderService : IRequestHandler<UpdateLabOrderRequest, UpdateLabOrderResponse>
    {
        private readonly IValidator<UpdateLabOrderRequest> _validator;

        private readonly IBaseCommandRepository<LabOrder> _repository;

        public UpdateLabOrderService(
            IValidator<UpdateLabOrderRequest> validator,
            IBaseCommandRepository<LabOrder> repository
)        {
            _validator = validator;
            _repository = repository;
        }

        public async Task<UpdateLabOrderResponse> Handle(
            UpdateLabOrderRequest request,
            CancellationToken cancellationToken)
        {
            return await UpdateLabOrderAsync(request);
        }

        private async Task<UpdateLabOrderResponse> UpdateLabOrderAsync(
            UpdateLabOrderRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            LabOrder? labOrder =
                await _repository.FindAsync(request.Id);

            if (labOrder == null)
            {
                throw new KeyNotFoundException(
                    $"Lab Order with Id {request.Id} not found.");
            }

            labOrder.PatientId = request.PatientId;
            labOrder.DoctorId = request.DoctorId;
            labOrder.Status = request.Status;
            labOrder.OrderedAt = request.OrderedAt;
            labOrder.UpdatedAt = DateTime.UtcNow;

            LabOrder? result =
                await _repository.UpdateAsync(labOrder);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to update Lab Order.");
            }

            return new UpdateLabOrderResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                DoctorId = result.DoctorId,
                Status = result.Status,
                OrderedAt = result.OrderedAt
            };
        }
    }
}