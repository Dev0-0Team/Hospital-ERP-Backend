using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.CreateMedicalRecord
{
    internal class CreateMedicalRecordService : IRequestHandler<CreateMedicalRecordRequest, CreateMedicalRecordResponse>
    {
        private readonly IBaseCommandRepository<MedicalRecord> _repository;
        private readonly IBaseQueryRepository<Patient> _patientRepository;
        private readonly IBaseQueryRepository<Doctor> _doctorRepository;
        private readonly IValidator<CreateMedicalRecordRequest> _validator;

        public CreateMedicalRecordService(
            IBaseCommandRepository<MedicalRecord> repository,
            IBaseQueryRepository<Patient> patientRepository,
            IBaseQueryRepository<Doctor> doctorRepository,
            IValidator<CreateMedicalRecordRequest> validator)
        {
            _repository = repository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _validator = validator;
        }

        public async Task<CreateMedicalRecordResponse> Handle(CreateMedicalRecordRequest request, CancellationToken cancellationToken)
        {
            return await CreateMedicalRecordAsync(request);
        }

        private async Task<CreateMedicalRecordResponse> CreateMedicalRecordAsync(CreateMedicalRecordRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Patient? patient = await _patientRepository.GetAsync(request.PatientId);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with Id {request.PatientId} not found.");
            }

            Doctor? doctor = await _doctorRepository.GetAsync(request.DoctorId);
            if (doctor == null)
            {
                throw new KeyNotFoundException($"Doctor with Id {request.DoctorId} not found.");
            }

            MedicalRecord medicalRecord = new()
            {
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                Diagnosis = request.Diagnosis,
                Notes = request.Notes,
                VisitDate = request.VisitDate,
                CreatedAt = DateTime.UtcNow
            };

            MedicalRecord? result = await _repository.CreateAsync(medicalRecord);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Medical Record.");
            }

            return new CreateMedicalRecordResponse
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