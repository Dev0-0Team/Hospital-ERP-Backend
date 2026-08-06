using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.CreatePatient
{
    internal class CreatePatientService : IRequestHandler<CreatePatientRequest, CreatePatientResponse>
    {
        private readonly IBaseCommandRepository<Patient> _repository;
        private readonly IBaseCommandRepository<Person> _personRepository;
        private readonly IValidator<CreatePatientRequest> _validator;

        public CreatePatientService
            (IBaseCommandRepository<Patient> repository, IBaseCommandRepository<Person> personRepository, 
            IValidator<CreatePatientRequest> validator)
        {
            _repository = repository;
            _personRepository = personRepository;
            _validator = validator;
        }

        public async Task<CreatePatientResponse> Handle(CreatePatientRequest request, CancellationToken cancellationToken)
        {
            return await CreatePatientAsync(request);
        }

        private async Task<CreatePatientResponse> CreatePatientAsync(CreatePatientRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool person = await _personRepository.IsExistAsync(request.PersonId);

            if (!person)
            {
                throw new KeyNotFoundException($"Person with Id {request.PersonId} not found.");
            }

            Patient nurse = new()
            {
                PersonId = request.PersonId,
                BloodType = request.BloodType.HasValue ? request.BloodType.Value.ToString()
                            .Replace("Positive", "+")
                            .Replace("Negative", "-")
                            : null,
                CreatedAt = DateTime.UtcNow
            };

            Patient? result = await _repository.CreateAsync(nurse);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Patient.");
            }

            return new CreatePatientResponse
            {
                Id = result.Id,
                PersonId = result.PersonId,
                BloodType = result.BloodType
            };
        }
    }
}
