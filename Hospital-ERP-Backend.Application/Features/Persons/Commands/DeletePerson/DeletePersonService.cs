

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Persons.Commands.DeletePerson
{
    internal class DeletePersonService : IRequestHandler<DeletePersonRequest, bool>
    {
        private readonly IValidator<DeletePersonRequest> _validator;
        private readonly IBaseCommandRepository<Person> _iPerson;

        public DeletePersonService(IValidator<DeletePersonRequest> validator, IBaseCommandRepository<Person> iPerson)
        {
            _validator = validator;
            _iPerson = iPerson;
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
            bool person = await _iPerson.IsExistAsync(request.Id);
            if (!person)
            {
                throw new KeyNotFoundException($"Person with Id {request.Id} not found.");
            }
            var isDeleted = await _iPerson.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete person with Id {request.Id}.");
            }
            return isDeleted;
        }
    }
}

