

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetRolePermissions
{
    public class GetRolePermissionsService
    {
        private readonly IBaseQueryRepository<RolePermission> _iRolePermission;
        private readonly IValidator<GetRolePermissionsRequest> _iValidator;

        public GetRolePermissionsService(IBaseQueryRepository<RolePermission> iRolePermission, IValidator<GetRolePermissionsRequest> iValidator)
        {
            _iRolePermission = iRolePermission;
            _iValidator = iValidator;
        }

        public async Task<GetRolePermissionsResponse> GetRolePermissionAsync(GetRolePermissionsRequest request)
        {
            var validationResult = await _iValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var rolePermission = await _iRolePermission.GetAsync(request.Id);
            if (rolePermission == null)
            {
                throw new KeyNotFoundException($"Role Permission with Id {request.Id} not found.");
            }
            return new GetRolePermissionsResponse
            {
                Id = rolePermission.Id,
                RoleId = rolePermission.RoleId,
                PermissionId = rolePermission.PermissionId
            };
        }
    }
}
