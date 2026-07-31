using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.UpdatePatient
{
    internal class UpdatePatientService : IRequestHandler<UpdatePatientRequest, UpdatePatientResponse>
    {
        private readonly IBaseCommandRepository<Patient> _repository;
        private readonly IBaseQueryRepository<Person> _personRepository;
        private readonly IBaseQueryRepository<Patient> _queryRepository;
        private readonly IValidator<UpdatePatientRequest> _validator;

        public UpdatePatientService(IBaseCommandRepository<Patient> repository, IBaseQueryRepository<Person> personRepository,
            IBaseQueryRepository<Patient> queryRepository, IValidator<UpdatePatientRequest> validator)
        {
            _repository = repository;
            _personRepository = personRepository;
            _queryRepository = queryRepository;
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

            Patient? patient = await _queryRepository.GetAsync(request.Id);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with Id {request.Id} not found.");
            }

            Person? person = await _personRepository.GetAsync(request.PersonId);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.PersonId} not found.");
            }

            patient.PersonId = request.PersonId;
            patient.BloodType = request.BloodType;
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
