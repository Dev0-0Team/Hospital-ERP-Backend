using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.UpdateMedicalRecord
{
    internal class UpdateMedicalRecordService : IRequestHandler<UpdateMedicalRecordRequest, UpdateMedicalRecordResponse>
    {
        private readonly IBaseCommandRepository<MedicalRecord> _repository;
        private readonly IBaseCommandRepository<Patient> _patientRepository;
        private readonly IBaseCommandRepository<Doctor> _doctorRepository;
        private readonly IValidator<UpdateMedicalRecordRequest> _validator;

        public UpdateMedicalRecordService(
            IBaseCommandRepository<MedicalRecord> repository,
            IBaseCommandRepository<Patient> patientRepository,
            IBaseCommandRepository<Doctor> doctorRepository,
            IValidator<UpdateMedicalRecordRequest> validator)
        {
            _repository = repository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _validator = validator;
        }

        public async Task<UpdateMedicalRecordResponse> Handle(UpdateMedicalRecordRequest request, CancellationToken cancellationToken)
        {
            return await UpdateMedicalRecordAsync(request);
        }

        private async Task<UpdateMedicalRecordResponse> UpdateMedicalRecordAsync(UpdateMedicalRecordRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            MedicalRecord? medicalRecord = await _repository.FindAsync(request.Id);
            if (medicalRecord == null)
            {
                throw new KeyNotFoundException($"Medical Record with Id {request.Id} not found.");
            }

            bool patient = await _patientRepository.IsExistAsync(request.PatientId);
            if (!patient)
            {
                throw new KeyNotFoundException($"Patient with Id {request.PatientId} not found.");
            }

            bool doctor = await _doctorRepository.IsExistAsync(request.DoctorId);
            if (!doctor)
            {
                throw new KeyNotFoundException($"Doctor with Id {request.DoctorId} not found.");
            }

            medicalRecord.PatientId = request.PatientId;
            medicalRecord.DoctorId = request.DoctorId;
            medicalRecord.Diagnosis = request.Diagnosis;
            medicalRecord.Notes = request.Notes;
            medicalRecord.VisitDate = request.VisitDate;
            medicalRecord.UpdatedAt = DateTime.UtcNow;

            MedicalRecord? result = await _repository.UpdateAsync(medicalRecord);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update Medical Record.");
            }

            return new UpdateMedicalRecordResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                DoctorId = result.DoctorId,
                Diagnosis = result.Diagnosis,
                Notes = result.Notes,
                VisitDate = result.VisitDate
            };
        }
    }
}