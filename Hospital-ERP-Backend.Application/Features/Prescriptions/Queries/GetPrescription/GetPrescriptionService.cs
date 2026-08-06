using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Queries.GetPrescription
{
    internal class GetPrescriptionService : IRequestHandler<GetPrescriptionRequest, GetPrescriptionResponse>
    {
        private readonly IBaseQueryRepository<Prescription> _repository;
        private readonly IValidator<GetPrescriptionRequest> _validator;

        public GetPrescriptionService(IBaseQueryRepository<Prescription> repository, IValidator<GetPrescriptionRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetPrescriptionResponse> Handle(GetPrescriptionRequest request,
            CancellationToken cancellationToken)
        {
            return await GetPrescriptionAsync(request);
        }

        private async Task<GetPrescriptionResponse> GetPrescriptionAsync(GetPrescriptionRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Prescription? prescription = await _repository.GetAsync(request.Id);

            if (prescription == null)
            {
                throw new KeyNotFoundException($"Prescription with Id {request.Id} not found.");
            }

            return new GetPrescriptionResponse
            {
                Id = prescription.Id,
                PatientId = prescription.PatientId,
                DoctorId = prescription.DoctorId
            };
        }
    }
}