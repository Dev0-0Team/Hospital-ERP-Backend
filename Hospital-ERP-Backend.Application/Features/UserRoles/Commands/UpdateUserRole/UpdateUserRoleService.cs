using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.UpdateUserRole
{
    internal class UpdateUserRoleService : IRequestHandler<UpdateUserRoleRequest, UpdateUserRoleResponse>
    {
        private readonly IBaseCommandRepository<UserRole> _iUserRole;
        private readonly IBaseQueryRepository<User> _iUserQuery;
        private readonly IBaseQueryRepository<Role> _iRoleQuery;
        private readonly IValidator<UpdateUserRoleRequest> _validator;
        private readonly IBaseQueryRepository<UserRole> _iUserRoleQuery;

        public UpdateUserRoleService(
            IBaseCommandRepository<UserRole> iUserRole,
            IBaseQueryRepository<User> iUserQuery,
            IBaseQueryRepository<Role> iRoleQuery,
            IValidator<UpdateUserRoleRequest> validator,
            IBaseQueryRepository<UserRole> iUserRoleQuery)
        {
            _iUserRole = iUserRole;
            _iUserQuery = iUserQuery;
            _iRoleQuery = iRoleQuery;
            _validator = validator;
            _iUserRoleQuery = iUserRoleQuery;
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

            UserRole? userRole = await _iUserRoleQuery.GetAsync(request.Id);
            if (userRole == null)
            {
                throw new KeyNotFoundException($"User Role with Id {request.Id} not found.");
            }

            User? isFound = await _iUserQuery.GetAsync(request.UserId);
            if (isFound == null)
            {
                throw new KeyNotFoundException($"User with Id {request.UserId} not found.");
            }

            Role? isRoleFound = await _iRoleQuery.GetAsync(request.RoleId);
            if (isRoleFound == null)
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
