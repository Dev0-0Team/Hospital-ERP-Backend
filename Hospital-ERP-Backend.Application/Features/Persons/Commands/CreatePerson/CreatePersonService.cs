using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonService
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

        public async Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request)
        {
            // Validate the request
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Person createPerson = new Person
            {
                FullName = request.FullName,
                Dob = request.Dob,
                Gender = request.Gender,
                Phone = request.Phone,
                Address = request.Address
            };

            Person result = (await _iPerson.CreateAsync(createPerson))!;
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
