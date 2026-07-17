using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Patients.Command.UpdatePatient
{
    public class UpdatePatientService : IRequestHandler<UpdatePatient, UpdatePatientCommand>
    {
        private readonly IValidator<UpdatePatient> _validator;
        private readonly IBaseCommandRepository<Patient> _iPerson;
        private readonly IBaseQueryRepository<Patient> _iQueryPerson;

        public UpdatePatientService(IValidator<UpdatePatient> validator, IBaseCommandRepository<Patient> iPerson, IBaseQueryRepository<Patient> iQueryPerson)
        {
            _validator = validator;
            _iPerson = iPerson;
            _iQueryPerson = iQueryPerson;
        }

        public async Task<UpdatePatientCommand> Handle(UpdatePatient request, CancellationToken cancellationToken)
        {
            return await UpdatePatientAsync(request);
        }

        private async Task<UpdatePatientCommand> UpdatePatientAsync(UpdatePatient request)
        {
            // Validate the request
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Patient createPatient = new Patient
            {

                PersonId = request.PersonId,
                BloodType = request.BloodType
            };

            Patient? result = await _iPerson.CreateAsync(createPatient);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Patient.");
            }

            return new UpdatePatientCommand
            {
                PersonId = result.PersonId,
                BloodType = result.BloodType
            };
        }
    }
}
