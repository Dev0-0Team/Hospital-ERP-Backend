

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonService : IRequestHandler<DeletePersonRequest, bool>
    {
        private readonly IValidator<DeletePersonRequest> _validator;
        private readonly IBaseCommandRepository<Person> _iPerson;
        private readonly IBaseQueryRepository<Person> _iPersonQuery;

        public DeletePersonService(IValidator<DeletePersonRequest> validator, IBaseCommandRepository<Person> iPerson, IBaseQueryRepository<Person> iPersonQuery)
        {
            _validator = validator;
            _iPerson = iPerson;
            _iPersonQuery = iPersonQuery;
        }

        public async Task<bool> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
        {
            return await DeletePersonAsync(request);
        }

        private async Task<bool> DeletePersonAsync(DeletePersonRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var person = await _iPersonQuery.GetAsync(request.Id);
            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.Id} not found.");
            }
            var isDeleted = await _iPerson.DeleteAsync(person.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete person with Id {request.Id}.");
            }
            return isDeleted;
        }
    }
}

