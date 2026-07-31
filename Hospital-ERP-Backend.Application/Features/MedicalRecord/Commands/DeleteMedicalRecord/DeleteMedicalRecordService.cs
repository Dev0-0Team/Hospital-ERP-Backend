using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.DeleteMedicalRecord
{
    internal class DeleteMedicalRecordService : IRequestHandler<DeleteMedicalRecordRequest, bool>
    {
        private readonly IBaseCommandRepository<MedicalRecord> _repository;
        private readonly IBaseQueryRepository<MedicalRecord> _queryRepository;
        private readonly IValidator<DeleteMedicalRecordRequest> _validator;

        public DeleteMedicalRecordService(
            IBaseCommandRepository<MedicalRecord> repository,
            IBaseQueryRepository<MedicalRecord> queryRepository,
            IValidator<DeleteMedicalRecordRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteMedicalRecordRequest request, CancellationToken cancellationToken)
        {
            return await DeleteMedicalRecordAsync(request);
        }

        private async Task<bool> DeleteMedicalRecordAsync(DeleteMedicalRecordRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            MedicalRecord? medicalRecord = await _queryRepository.GetAsync(request.Id);

            if (medicalRecord == null)
            {
                throw new KeyNotFoundException($"Medical Record with Id {request.Id} not found.");
            }

            bool result = await _repository.DeleteAsync(request.Id);

            if (!result)
            {
                throw new InvalidOperationException("Failed to delete medical record.");
            }

            return result;
        }
    }
}