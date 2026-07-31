using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Queries.GetMedicalRecord
{
    internal class GetMedicalRecordService : IRequestHandler<GetMedicalRecordRequest, GetMedicalRecordResponse>
    {
        private readonly IBaseQueryRepository<MedicalRecord> _repository;
        private readonly IValidator<GetMedicalRecordRequest> _validator;

        public GetMedicalRecordService(
            IBaseQueryRepository<MedicalRecord> repository,
            IValidator<GetMedicalRecordRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetMedicalRecordResponse> Handle(GetMedicalRecordRequest request, CancellationToken cancellationToken)
        {
            return await GetMedicalRecordAsync(request);
        }

        private async Task<GetMedicalRecordResponse> GetMedicalRecordAsync(GetMedicalRecordRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            MedicalRecord? medicalRecord = await _repository.GetAsync(request.Id);

            if (medicalRecord == null)
            {
                throw new KeyNotFoundException($"Medical Record with Id {request.Id} not found.");
            }

            return new GetMedicalRecordResponse
            {
                Id = medicalRecord.Id,
                PatientId = medicalRecord.PatientId,
                DoctorId = medicalRecord.DoctorId,
                Diagnosis = medicalRecord.Diagnosis,
                Notes = medicalRecord.Notes,
                VisitDate = medicalRecord.VisitDate
            };
        }
    }
}