using FluentValidation;
using Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.CreateMedicalRecord;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Invoices.Commands.CreateInvoice
{
    internal class CreateInvoiceService : IRequestHandler<CreateInvoiceRequest, CreateInvoiceResponse>
    {
        private IBaseCommandRepository<Invoice> _repository;
        private IValidator<CreateInvoiceRequest> _validator;
        private IBaseQueryRepository<Patient> _queryRepository;

        public CreateInvoiceService(IBaseCommandRepository<Invoice> repository, IValidator<CreateInvoiceRequest> validator, IBaseQueryRepository<Patient> queryRepository)
        {
            _repository = repository;
            _validator = validator;
            _queryRepository = queryRepository;
        }

        public async Task<CreateInvoiceResponse> Handle(CreateInvoiceRequest request, CancellationToken cancellationToken)
        {
            return await CreateInvoiceAsync(request);
        }

        private async Task<CreateInvoiceResponse> CreateInvoiceAsync(CreateInvoiceRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Patient? patient = await _queryRepository.GetAsync(request.PatientId);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with Id {request.PatientId} not found.");
            }
            

            Invoice invoice = new()
            {
                PatientId = request.PatientId,
                Status = request.Status.ToString(),
                TotalAmount = request.TotalAmount,
                CreatedAt = DateTime.UtcNow
            };

            Invoice? result = await _repository.CreateAsync(invoice);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Invoice.");
            }

            return new CreateInvoiceResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                Status = request.Status.ToString(),
                TotalAmount = request.TotalAmount
            };
        }
    }
}