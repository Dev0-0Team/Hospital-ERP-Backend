using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Command.UpdateRolePermission
{
    internal class UpdateRolePermissionService : IRequestHandler<UpdateRolePermissionRequest, UpdateRolePermissionResponse>
    {
        private readonly IBaseCommandRepository<RolePermission> _iRolePermission;
        private readonly IBaseCommandRepository<Role> _iRoleCommand;
        private readonly IBaseCommandRepository<Permission> _iPermissionCommand;
        private readonly IValidator<UpdateRolePermissionRequest> _iValidator;

        public UpdateRolePermissionService(
            IBaseCommandRepository<RolePermission> iRolePermission,
            IBaseCommandRepository<Role> iRoleQuery,
            IBaseCommandRepository<Permission> iPermissionQuery,
            IValidator<UpdateRolePermissionRequest> iValidator,
            IBaseQueryRepository<RolePermission> iRolePermissionQuery)
        {
            _iRolePermission = iRolePermission;
            _iRoleCommand = iRoleQuery;
            _iPermissionCommand = iPermissionQuery;
            _iValidator = iValidator;
        }

        public async Task<UpdateRolePermissionResponse> Handle(UpdateRolePermissionRequest request, CancellationToken cancellationToken)
        {
            return await UpdateRolePermissionAsync(request);
        }

        private async Task<UpdateRolePermissionResponse> UpdateRolePermissionAsync(UpdateRolePermissionRequest request)
        {
            var validationResult = await _iValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            RolePermission? rolePermission = await _iRolePermission.FindAsync(request.Id);
            if (rolePermission == null)
            {
                throw new KeyNotFoundException($"RolePermission with Id {request.Id} not found.");
            }

            bool role = await _iRoleCommand.IsExistAsync(request.RoleId);
            if (!role)
            {
                throw new KeyNotFoundException($"Role with Id {request.RoleId} not found.");
            }

            bool permission = await _iPermissionCommand.IsExistAsync(request.PermissionId);
            if (!permission)
            {
                throw new KeyNotFoundException($"Permission with Id {request.PermissionId} not found.");
            }

            rolePermission.RoleId = request.RoleId;
            rolePermission.PermissionId = request.PermissionId;
            rolePermission.UpdatedAt = DateTime.UtcNow;

            RolePermission? result = await _iRolePermission.UpdateAsync(rolePermission);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update Role Permission.");
            }

            return new UpdateRolePermissionResponse
            {
                Id = result.Id,
                RoleId = result.RoleId,
                PermissionId = result.PermissionId
            };
        }
    }
}
