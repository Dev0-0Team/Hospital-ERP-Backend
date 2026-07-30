

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.DeleteUserRole
{
    internal class DeleteUserRoleService : IRequestHandler<DeleteUserRoleRequest, bool>
    {
        private readonly IBaseCommandRepository<UserRole> _iUserRole;
        private readonly IValidator<DeleteUserRoleRequest> _validator;

        public DeleteUserRoleService(IBaseCommandRepository<UserRole> iUserRole, IValidator<DeleteUserRoleRequest> validator)
        {
            _iUserRole = iUserRole;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteUserRoleRequest request, CancellationToken cancellationToken)
        {
            return await DeleteUserRoleAsync(request);
        }

        private async Task<bool> DeleteUserRoleAsync(DeleteUserRoleRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            bool userRole = await _iUserRole.IsExistAsync(request.Id);
            if (!userRole)
            {
                throw new KeyNotFoundException($"User Role with Id {request.Id} not found.");
            }
            bool isDeleted = await _iUserRole.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete user role with Id {request.Id}.");
            }
            return isDeleted;
        }
    }
}
