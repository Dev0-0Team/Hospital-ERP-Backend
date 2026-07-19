using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Queries.GetAllPaymentMethods
{
    public class GetAllPaymentMethodsService : IRequestHandler<GetAllPaymentMethodsRequest, IEnumerable<GetAllPaymentMethodsResponse>>
    {
        private readonly IBaseQueryRepository<PaymentMethod> _repository;
        private readonly IValidator<GetAllPaymentMethodsRequest> _validator;

        public GetAllPaymentMethodsService(IBaseQueryRepository<PaymentMethod> repository, IValidator<GetAllPaymentMethodsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllPaymentMethodsResponse>> Handle(GetAllPaymentMethodsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllPaymentMethodsAsync(request);
        }

        private async Task<IEnumerable<GetAllPaymentMethodsResponse>> GetAllPaymentMethodsAsync(GetAllPaymentMethodsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            IEnumerable<PaymentMethod> list = await _repository.GetAllAsync(request.Page);
            if (list == null || list.Count() == 0)
            {
                throw new KeyNotFoundException($"No payment method found on page {request.Page}.");
            }

            return list.Select(p => new GetAllPaymentMethodsResponse
            {
                Id = p.Id,
                Name = p.Name
            });
        }
    }
}
