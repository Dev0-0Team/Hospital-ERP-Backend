using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.UpdatePatient
{
    internal class UpdatePatientService : IRequestHandler<UpdatePatientRequest, UpdatePatientResponse>
    {
        private readonly IBaseCommandRepository<Patient> _repository;
        private readonly IBaseCommandRepository<Person> _personRepository;
        private readonly IValidator<UpdatePatientRequest> _validator;

        public UpdatePatientService(IBaseCommandRepository<Patient> repository, IBaseCommandRepository<Person> personRepository, IValidator<UpdatePatientRequest> validator)
        {
            _repository = repository;
            _personRepository = personRepository;
            _validator = validator;
        }

        public async Task<UpdatePatientResponse> Handle(UpdatePatientRequest request, CancellationToken cancellationToken)
        {
            return await UpdatePatientAsync(request);
        }

        private async Task<UpdatePatientResponse> UpdatePatientAsync(UpdatePatientRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Patient? patient = await _repository.FindAsync(request.Id);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with Id {request.Id} not found.");
            }

            bool person = await _personRepository.IsExistAsync(request.PersonId);

            if (!person)
            {
                throw new KeyNotFoundException($"Person with Id {request.PersonId} not found.");
            }

            patient.PersonId = request.PersonId;
            patient.BloodType = request.BloodType.HasValue ?
                request.BloodType.Value.ToString()
                    .Replace("Positive", "+")
                    .Replace("Negative", "-")
                    : null;
            patient.UpdatedAt = DateTime.UtcNow;

            Patient? result = await _repository.UpdateAsync(patient);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to Update Patient.");
            }

            return new UpdatePatientResponse
            {
                Id = result.Id,
                PersonId = result.PersonId,
                BloodType = result.BloodType
            };
        }
    }
}