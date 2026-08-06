using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Invoices.Queries.GetAllInvoices
{
    internal class GetAllInvoicesService : IRequestHandler<GetAllInvoicesRequest, IEnumerable<GetAllInvoicesResponse>>
    {
        private readonly IBaseQueryRepository<Invoice> _repository;
        private readonly IValidator<GetAllInvoicesRequest> _validator;

        public GetAllInvoicesService(IBaseQueryRepository<Invoice> repository, IValidator<GetAllInvoicesRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllInvoicesResponse>> Handle(GetAllInvoicesRequest request, CancellationToken cancellationToken)
        {
            return await GetAllInvoicesAsync(request);
        }

        private async Task<IEnumerable<GetAllInvoicesResponse>> GetAllInvoicesAsync(GetAllInvoicesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            IEnumerable<Invoice> invoices = await _repository.GetAllAsync(request.Page);
            if (invoices == null || !invoices.Any())
            {
                throw new KeyNotFoundException($"No invoices found on page {request.Page}.");
            }

            return invoices.Select(x => new GetAllInvoicesResponse
            {
                Id = x.Id,
                PatientId = x.PatientId,
                TotalAmount = x.TotalAmount,
                Status = x.Status
            });
        }
    }
}