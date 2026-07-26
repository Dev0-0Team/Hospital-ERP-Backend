using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Persons.Commands.CreatePerson
{
    internal class CreatePersonService : IRequestHandler<CreatePersonRequest, CreatePersonResponse>
    {
        private readonly IValidator<CreatePersonRequest> _validator;
        private readonly IBaseCommandRepository<Person> _iPerson;
        private readonly IBaseQueryRepository<Person> _iQueryPerson;

        public CreatePersonService(IValidator<CreatePersonRequest> validator, IBaseCommandRepository<Person> iPerson, IBaseQueryRepository<Person> iQueryPerson)
        {
            _validator = validator;
            _iPerson = iPerson;
            _iQueryPerson = iQueryPerson;
        }

        public async Task<CreatePersonResponse> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            return await CreatePersonAsync(request);
        }

        private async Task<CreatePersonResponse> CreatePersonAsync(CreatePersonRequest request)
        {
            // Validate the request
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Person createPerson = new Person
            {
                FullName = request.FullName,
                Dob = request.Dob,
                Gender = request.Gender.ToString(),
                Phone = request.Phone,
                Address = request.Address,
                CreatedAt = DateTime.UtcNow
            };

            Person? result = await _iPerson.CreateAsync(createPerson);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create person.");
            }

            return new CreatePersonResponse
            {
                Id = result.Id,
                FullName = result.FullName,
                Dob = result.Dob,
                Gender = result.Gender,
                Phone = result.Phone,
                Address = result.Address
            };
        }
    }
}
