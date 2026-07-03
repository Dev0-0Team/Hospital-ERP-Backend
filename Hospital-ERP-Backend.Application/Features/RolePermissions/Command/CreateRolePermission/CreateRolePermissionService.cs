

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Command.CreateRolePermission
{
    public class CreateRolePermissionService
    {
        private readonly IBaseCommandRepository<RolePermission> _iRolePermission;
        private readonly IBaseQueryRepository<Role> _iRoleQuery;
        private readonly IBaseQueryRepository<Permission> _iPermissionQuery;
        private readonly IValidator<CreateRolePermissionRequest> _iValidator;

        public CreateRolePermissionService(
            IBaseCommandRepository<RolePermission> iRolePermission,
            IBaseQueryRepository<Role> iRoleQuery,
            IBaseQueryRepository<Permission> iPermissionQuery,
            IValidator<CreateRolePermissionRequest> iValidator)
        {
            _iRolePermission = iRolePermission;
            _iRoleQuery = iRoleQuery;
            _iPermissionQuery = iPermissionQuery;
            _iValidator = iValidator;
        }

        public async Task<CreateRolePermissionResponse> CreateRolePermissionAsync(CreateRolePermissionRequest request)
        {
            var validationResult = await _iValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Role? isRoleFound = await _iRoleQuery.GetAsync(request.RoleId);
            if (isRoleFound == null)
            {
                throw new KeyNotFoundException($"Role with Id {request.RoleId} not found.");
            }

            Permission? isPermissionFound = await _iPermissionQuery.GetAsync(request.PermissionId);
            if (isPermissionFound == null)
            {
                throw new KeyNotFoundException($"Permission with Id {request.PermissionId} not found.");
            }

            RolePermission createRolePermission = new RolePermission()
            {
                RoleId = request.RoleId,
                PermissionId = request.PermissionId
            };

            RolePermission? result = await _iRolePermission.CreateAsync(createRolePermission);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Role Permission.");
            }

            return new CreateRolePermissionResponse
            {
                Id = result.Id,
                RoleId = result.RoleId,
                PermissionId = result.PermissionId
            };
        }
    }
}
