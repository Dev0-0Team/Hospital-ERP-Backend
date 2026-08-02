using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.DeleteMedicalRecord
{
    internal class DeleteMedicalRecordService : IRequestHandler<DeleteMedicalRecordRequest, bool>
    {
        private readonly IBaseCommandRepository<MedicalRecord> _repository;
        private readonly IValidator<DeleteMedicalRecordRequest> _validator;

        public DeleteMedicalRecordService(
            IBaseCommandRepository<MedicalRecord> repository, IValidator<DeleteMedicalRecordRequest> validator)
        {
            _repository = repository;
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

            bool medicalRecord = await _repository.IsExistAsync(request.Id);

            if (!medicalRecord)
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