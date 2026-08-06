using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.UpdateUserRole
{
    internal class UpdateUserRoleService : IRequestHandler<UpdateUserRoleRequest, UpdateUserRoleResponse>
    {
        private readonly IBaseCommandRepository<UserRole> _iUserRole;
        private readonly IBaseCommandRepository<User> _iUserCommand;
        private readonly IBaseCommandRepository<Role> _iRoleCommand;
        private readonly IValidator<UpdateUserRoleRequest> _validator;

        public UpdateUserRoleService(
            IBaseCommandRepository<UserRole> iUserRole,
            IBaseCommandRepository<User> iUserQuery,
            IBaseCommandRepository<Role> iRoleQuery,
            IValidator<UpdateUserRoleRequest> validator)
        {
            _iUserRole = iUserRole;
            _iUserCommand = iUserQuery;
            _iRoleCommand = iRoleQuery;
            _validator = validator;
        }

        public async Task<UpdateUserRoleResponse> Handle(UpdateUserRoleRequest request, CancellationToken cancellationToken)
        {
            return await UpdateUserRoleAsync(request);
        }

        private async Task<UpdateUserRoleResponse> UpdateUserRoleAsync(UpdateUserRoleRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            UserRole? userRole = await _iUserRole.FindAsync(request.Id);
            if (userRole == null)
            {
                throw new KeyNotFoundException($"User Role with Id {request.Id} not found.");
            }

            bool isFound = await _iUserCommand.IsExistAsync(request.UserId);
            if (!isFound)
            {
                throw new KeyNotFoundException($"User with Id {request.UserId} not found.");
            }

            bool isRoleFound = await _iRoleCommand.IsExistAsync(request.RoleId);
            if (!isRoleFound)
            {
                throw new KeyNotFoundException($"Role with Id {request.RoleId} not found.");
            }
            userRole.UserId = request.UserId;
            userRole.RoleId = request.RoleId;
            userRole.UpdatedAt = DateTime.UtcNow;

            UserRole? result = await _iUserRole.UpdateAsync(userRole);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update User Role.");
            }

            return new UpdateUserRoleResponse
            {
                Id = result.Id,
                UserId = result.UserId,
                RoleId = result.RoleId
            };
        }
    }
}
