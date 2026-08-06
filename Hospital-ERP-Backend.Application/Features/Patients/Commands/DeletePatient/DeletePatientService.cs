using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.DeletePatient
{
    internal class DeletePatientService : IRequestHandler<DeletePatientRequest, bool>
    {
        private readonly IBaseCommandRepository<Patient> _repository;
        private readonly IValidator<DeletePatientRequest> _validator;

        public DeletePatientService(IBaseCommandRepository<Patient> repository, IValidator<DeletePatientRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeletePatientRequest request, CancellationToken cancellationToken)
        {
            return await DeletePatientAsync(request);
        }

        private async Task<bool> DeletePatientAsync(DeletePatientRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool patient = await _repository.IsExistAsync(request.Id);

            if (!patient)
            {
                throw new KeyNotFoundException($"Patient with Id {request.Id} not found.");
            }

            bool result = await _repository.DeleteAsync(request.Id);

            if (!result)
            {
                throw new InvalidOperationException("Failed to delete patient.");
            }

            return result;
        }
    }
}
