
using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Persons.Commands.UpdatePerson
{
    internal class UpdatePersonService : IRequestHandler<UpdatePersonRequest, UpdatePersonResponse>
    {
        private readonly IValidator<UpdatePersonRequest> _validator;
        private readonly IBaseCommandRepository<Person> _iPerson;

        public UpdatePersonService(IValidator<UpdatePersonRequest> validator, IBaseCommandRepository<Person> iPerson)
        {
            _validator = validator;
            _iPerson = iPerson;
        }

        public async Task<UpdatePersonResponse> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
        {
            return await UpdatePersonAsync(request);
        }

        private async Task<UpdatePersonResponse> UpdatePersonAsync(UpdatePersonRequest request)
        {
            // Validate the request
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            // Retrieve the existing person from the database
            Person? existingPerson = await _iPerson.FindAsync(request.Id);
            if (existingPerson == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.Id} not found.");
            }
            existingPerson.FullName = request.FullName;
            existingPerson.Dob = request.Dob;
            existingPerson.Gender = request.Gender.ToString();
            existingPerson.Phone = request.Phone;
            existingPerson.Address = request.Address;
            existingPerson.UpdatedAt = DateTime.UtcNow;

            Person? result = await _iPerson.UpdateAsync(existingPerson);

            if (result == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.Id} not found.");
            }

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
