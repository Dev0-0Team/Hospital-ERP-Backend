using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Queries.GetAllLabOrders
{
    internal class GetAllLabOrdersService : IRequestHandler<GetAllLabOrdersRequest, IEnumerable<GetAllLabOrdersResponse>>
    {
        private readonly IBaseQueryRepository<LabOrder> _labOrderQueryRepository;

        private readonly IValidator<GetAllLabOrdersRequest> _validator;
        public GetAllLabOrdersService(IBaseQueryRepository<LabOrder> labOrderQueryRepository, IValidator<GetAllLabOrdersRequest> validator)
        {
            _labOrderQueryRepository = labOrderQueryRepository;
            _validator = validator;
        }
        public async Task<IEnumerable<GetAllLabOrdersResponse>> Handle(GetAllLabOrdersRequest request, CancellationToken cancellationToken)
        {
            return await GetAllLabOrdersAsync(request);
        }


        private async Task<IEnumerable<GetAllLabOrdersResponse>> GetAllLabOrdersAsync(GetAllLabOrdersRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));

            IEnumerable<LabOrder> labOrders = await _labOrderQueryRepository.GetAllAsync(request.Page);

            if (labOrders == null || labOrders.Count() == 0)
                throw new KeyNotFoundException($"No lab orders found on page {request.Page}.");

            return labOrders
                .Select(x => new GetAllLabOrdersResponse
                {
                    Id = x.Id,
                    PatientId = x.PatientId,
                    DoctorId = x.DoctorId,
                    Status = x.Status,
                    OrderedAt = x.OrderedAt
                });
        }
    }
}
