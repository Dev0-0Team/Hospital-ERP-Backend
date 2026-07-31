using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Queries.GetLabOrder
{
    internal class GetLabOrderService : IRequestHandler<GetLabOrderRequest, GetLabOrderResponse>
    {
        private readonly IBaseQueryRepository<LabOrder> _repository;
        private readonly IValidator<GetLabOrderRequest> _validator;

        public GetLabOrderService(IBaseQueryRepository<LabOrder> repository, IValidator<GetLabOrderRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetLabOrderResponse> Handle(GetLabOrderRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));

            LabOrder? labOrder = await _repository.GetAsync(request.Id);

            if (labOrder == null)
                throw new KeyNotFoundException($"Lab Order with Id {request.Id} not found.");

            return new GetLabOrderResponse
            {
                Id = labOrder.Id,
                PatientId = labOrder.PatientId,
                DoctorId = labOrder.DoctorId,
                Status = labOrder.Status,
                OrderedAt = labOrder.OrderedAt
            };
        }
    }
}