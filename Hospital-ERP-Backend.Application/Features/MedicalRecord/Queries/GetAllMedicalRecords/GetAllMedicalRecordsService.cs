using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Queries.GetAllMedicalRecords
{
    internal class GetAllMedicalRecordsService : IRequestHandler<GetAllMedicalRecordsRequest, IEnumerable<GetAllMedicalRecordsResponse>>
    {
        private readonly IBaseQueryRepository<MedicalRecord> _repository;
        private readonly IValidator<GetAllMedicalRecordsRequest> _validator;

        public GetAllMedicalRecordsService(
            IBaseQueryRepository<MedicalRecord> repository,
            IValidator<GetAllMedicalRecordsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllMedicalRecordsResponse>> Handle(GetAllMedicalRecordsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllMedicalRecordsAsync(request);
        }

        private async Task<IEnumerable<GetAllMedicalRecordsResponse>> GetAllMedicalRecordsAsync(GetAllMedicalRecordsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var medicalRecords = await _repository.GetAllAsync(request.Page);

            if (medicalRecords == null || !medicalRecords.Any())
            {
                throw new KeyNotFoundException($"No medical records found on page {request.Page}");
            }

            return medicalRecords.Select(x => new GetAllMedicalRecordsResponse
            {
                Id = x.Id,
                PatientId = x.PatientId,
                DoctorId = x.DoctorId,
                Diagnosis = x.Diagnosis,
                Notes = x.Notes,
                VisitDate = x.VisitDate
            });
        }
    }
}