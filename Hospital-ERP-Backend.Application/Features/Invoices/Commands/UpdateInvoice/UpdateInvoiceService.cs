using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Invoices.Commands.UpdateInvoice
{
    public class UpdateInvoiceService : IRequestHandler<UpdateInvoiceRequest, UpdateInvoiceResponse>
    {
        private readonly IBaseCommandRepository<Invoice> _repository;
        private readonly IBaseQueryRepository<Invoice> _queryRepository;
        private readonly IBaseQueryRepository<Patient> _patientRepository;
        private readonly IValidator<UpdateInvoiceRequest> _validator;

        public UpdateInvoiceService(
            IBaseCommandRepository<Invoice> repository,
            IBaseQueryRepository<Invoice> queryRepository,
            IBaseQueryRepository<Patient> patientRepository,
            IValidator<UpdateInvoiceRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _patientRepository = patientRepository;
            _validator = validator;
        }

        public async Task<UpdateInvoiceResponse> Handle(UpdateInvoiceRequest request, CancellationToken cancellationToken)
        {
            return await UpdateInvoiceAsync(request);
        }

        private async Task<UpdateInvoiceResponse> UpdateInvoiceAsync(UpdateInvoiceRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Invoice? invoice = await _queryRepository.GetAsync(request.Id);
            if (invoice == null)
            {
                throw new KeyNotFoundException($"Invoice with Id {request.Id} not found.");
            }

            Patient? patient = await _patientRepository.GetAsync(request.PatientId);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with Id {request.PatientId} not found.");
            }

            invoice.PatientId = request.PatientId;
            invoice.TotalAmount = request.TotalAmount;
            invoice.Status = request.Status.ToString();
            invoice.UpdatedAt = DateTime.UtcNow;

            Invoice? result = await _repository.UpdateAsync(invoice);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update Invoice.");
            }

            return new UpdateInvoiceResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                TotalAmount = result.TotalAmount,
                Status = result.Status
            };
        }
    }
}