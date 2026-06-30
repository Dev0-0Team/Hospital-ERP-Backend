

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserService
    {
        private readonly IValidator<DeleteUserRequest> _validator;
        private readonly IBaseCommandRepository<User> _iUser;
        private readonly IBaseQueryRepository<User> _iUserQuery;

        public DeleteUserService(IValidator<DeleteUserRequest> validator, IBaseCommandRepository<User> iUser, IBaseQueryRepository<User> iUserQuery)
        {
            _validator = validator;
            _iUser = iUser;
            _iUserQuery = iUserQuery;
        }

        public async Task<bool> DeleteUserAsync(DeleteUserRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var person = await _iUserQuery.GetAsync(request.Id);
            if (person == null)
            {
                throw new KeyNotFoundException($"User with Id {request.Id} not found.");
            }
            var isDeleted = await _iUser.DeleteAsync(person.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete user with Id {request.Id}.");
            }
            return isDeleted;
        }
    }
}
