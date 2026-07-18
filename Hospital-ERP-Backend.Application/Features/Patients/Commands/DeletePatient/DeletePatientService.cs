using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientService : IRequestHandler<DeletePatientRequest, bool>
    {
        private readonly IBaseCommandRepository<Patient> _iPermission;
        private readonly IValidator<DeletePatientRequest> _validator;
        private readonly IBaseQueryRepository<Patient> _iQueryPermission;

        public DeletePatientService(IBaseCommandRepository<Patient> iPermission, IValidator<DeletePatientRequest> validator, IBaseQueryRepository<Patient> iQueryPermission)
        {
            _iPermission = iPermission;
            _validator = validator;
            _iQueryPermission = iQueryPermission;
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
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            Patient? patient = await _iQueryPermission.GetAsync(request.PersonId);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Permission with Id {request.PersonId} not found.");
            }
            var isDeleted = await _iPermission.DeleteAsync(patient.PersonId);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete permission with Id {request.PersonId}.");
            }
            return isDeleted;
        }
    }
}
