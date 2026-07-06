using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Command.UpdateRolePermission
{
    public class UpdateRolePermissionService : IRequestHandler<UpdateRolePermissionRequest, UpdateRolePermissionResponse>
    {
        private readonly IBaseCommandRepository<RolePermission> _iRolePermission;
        private readonly IBaseQueryRepository<RolePermission> _iRolePermissionQuery;
        private readonly IBaseQueryRepository<Role> _iRoleQuery;
        private readonly IBaseQueryRepository<Permission> _iPermissionQuery;
        private readonly IValidator<UpdateRolePermissionRequest> _iValidator;

        public UpdateRolePermissionService(
            IBaseCommandRepository<RolePermission> iRolePermission,
            IBaseQueryRepository<Role> iRoleQuery,
            IBaseQueryRepository<Permission> iPermissionQuery,
            IValidator<UpdateRolePermissionRequest> iValidator,
            IBaseQueryRepository<RolePermission> iRolePermissionQuery)
        {
            _iRolePermission = iRolePermission;
            _iRoleQuery = iRoleQuery;
            _iPermissionQuery = iPermissionQuery;
            _iValidator = iValidator;
            _iRolePermissionQuery = iRolePermissionQuery;
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
            RolePermission? rolePermission = await _iRolePermissionQuery.GetAsync(request.Id);
            if (rolePermission == null)
            {
                throw new KeyNotFoundException($"RolePermission with Id {request.Id} not found.");
            }
            var role = await _iRoleQuery.GetAsync(request.RoleId);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with Id {request.RoleId} not found.");
            }
            var permission = await _iPermissionQuery.GetAsync(request.PermissionId);
            if (permission == null)
            {
                throw new KeyNotFoundException($"Permission with Id {request.PermissionId} not found.");
            }
            rolePermission.RoleId = request.RoleId;
            rolePermission.PermissionId = request.PermissionId;
            rolePermission.UpdatedAt = DateTime.Now;

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
