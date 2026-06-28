using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;


namespace Hospital_ERP_Backend.Application.Features.Persons.Queries.GetPerson
{
    public class GetPersonService
    {
        private readonly IValidator<GetPersonRequest> _validator;
        private readonly IBaseQueryRepository<Person> _iPerson;

        public GetPersonService(IValidator<GetPersonRequest> validator, IBaseQueryRepository<Person> iPerson)
        {
            _validator = validator;
            _iPerson = iPerson;
        }

        public async Task<GetPersonResponse> GetPersonAsync(GetPersonRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var person = await _iPerson.GetAsync(request.Id);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.Id} not found.");
            }

            return new GetPersonResponse
            {
                Id = person.Id,
                FullName = person.FullName,
                Dob = person.Dob,
                Gender = person.Gender,
                Phone = person.Phone,
                Address = person.Address
            };
        }
    }
}
