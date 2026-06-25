
using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonService
    {
        private readonly IValidator<UpdatePersonRequest> _validator;
        private readonly IBaseCommandRepository<Person> _iPerson;
        private readonly IBaseQueryRepository<Person> _iQueryPerson;

        public UpdatePersonService(IValidator<UpdatePersonRequest> validator, IBaseCommandRepository<Person> iPerson, IBaseQueryRepository<Person> iQueryPerson)
        {
            _validator = validator;
            _iPerson = iPerson;
            _iQueryPerson = iQueryPerson;
        }

        public async Task<UpdatePersonResponse> UpdatePersonAsync(UpdatePersonRequest request)
        {
            // Validate the request
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            // Retrieve the existing person from the database
            Person? existingPerson = await _iQueryPerson.GetAsync(request.Id);
            if (existingPerson == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.Id} not found.");
            }
            existingPerson.FullName = request.FullName;
            existingPerson.Dob = request.Dob;
            existingPerson.Gender = request.Gender;
            existingPerson.Phone = request.Phone;
            existingPerson.Address = request.Address;
            existingPerson.UpdatedAt = DateTime.Now;

            Person result = (await _iPerson.UpdateAsync(existingPerson))!;
            return new UpdatePersonResponse
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
