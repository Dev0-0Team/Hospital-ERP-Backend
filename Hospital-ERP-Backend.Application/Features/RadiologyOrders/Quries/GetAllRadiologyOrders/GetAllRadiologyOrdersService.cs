using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Queries.GetAllRadiologyOrders
{
    public class GetAllRadiologyOrdersService
        : IRequestHandler<GetAllRadiologyOrdersRequest,
            IEnumerable<GetAllRadiologyOrdersResponse>>
    {
        private readonly IBaseQueryRepository<RadiologyOrder> _repository;

        private readonly IValidator<GetAllRadiologyOrdersRequest> _validator;

        public GetAllRadiologyOrdersService(
            IBaseQueryRepository<RadiologyOrder> repository,
            IValidator<GetAllRadiologyOrdersRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllRadiologyOrdersResponse>> Handle(
            GetAllRadiologyOrdersRequest request,
            CancellationToken cancellationToken)
        {
            return await GetAllRadiologyOrdersAsync(request);
        }

        private async Task<IEnumerable<GetAllRadiologyOrdersResponse>>
            GetAllRadiologyOrdersAsync(GetAllRadiologyOrdersRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var orders =
                await _repository.GetAllAsync(request.Page);

            if (orders == null || !orders.Any())
            {
                throw new KeyNotFoundException(
                    $"No Radiology Orders found on page {request.Page}.");
            }

            return orders.Select(x =>
                new GetAllRadiologyOrdersResponse
                {
                    Id = x.Id,
                    PatientId = x.PatientId,
                    DoctorId = x.DoctorId,
                    Type = x.Type,
                    Status = x.Status,
                    OrderedAt = x.OrderedAt
                });
        }
    }
}