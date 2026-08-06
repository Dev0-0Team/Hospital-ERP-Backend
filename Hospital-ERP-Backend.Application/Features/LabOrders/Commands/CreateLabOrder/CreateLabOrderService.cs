using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Commands.CreateLabOrder
{
    internal class CreateLabOrderService : IRequestHandler<CreateLabOrderRequest, CreateLabOrderResponse>
    {
        private readonly IBaseCommandRepository<LabOrder> _repository;
        private readonly IValidator<CreateLabOrderRequest> _validator;

        public CreateLabOrderService(
            IBaseCommandRepository<LabOrder> repository,
            IValidator<CreateLabOrderRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateLabOrderResponse> Handle(
            CreateLabOrderRequest request,
            CancellationToken cancellationToken)
        {
            return await CreateLabOrderAsync(request);
        }

        private async Task<CreateLabOrderResponse> CreateLabOrderAsync(
            CreateLabOrderRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            LabOrder labOrder = new()
            {
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                Status = request.Status,
                OrderedAt = request.OrderedAt
            };

            LabOrder? result = await _repository.CreateAsync(labOrder);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to create Lab Order.");
            }

            return new CreateLabOrderResponse
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