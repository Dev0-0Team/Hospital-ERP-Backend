

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Users.Commands.DeleteUser
{
    internal class DeleteUserService : IRequestHandler<DeleteUserRequest, bool>
    {
        private readonly IValidator<DeleteUserRequest> _validator;
        private readonly IBaseCommandRepository<User> _iUser;

        public DeleteUserService(IValidator<DeleteUserRequest> validator, IBaseCommandRepository<User> iUser)
        {
            _validator = validator;
            _iUser = iUser;
        }

        public async Task<bool> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            return await DeleteUserAsync(request);
        }

        private async Task<bool> DeleteUserAsync(DeleteUserRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool user = await _iUser.IsExistAsync(request.Id);
            if (!user)
            {
                throw new KeyNotFoundException($"User with Id {request.Id} not found.");
            }
            var isDeleted = await _iUser.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete user with Id {request.Id}.");
            }
            return isDeleted;
        }
    }
}
