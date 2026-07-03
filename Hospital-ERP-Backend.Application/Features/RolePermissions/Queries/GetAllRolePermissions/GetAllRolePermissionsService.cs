

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetAllRolePermissions
{
    public class GetAllRolePermissionsService
    {
        private readonly IBaseQueryRepository<RolePermission> _iRolePermission;
        private readonly IValidator<GetAllRolePermissionsRequest> _validator;

        public GetAllRolePermissionsService(IValidator<GetAllRolePermissionsRequest> validator, IBaseQueryRepository<RolePermission> iRolePermission)
        {
            _validator = validator;
            _iRolePermission = iRolePermission;
        }

        public async Task<IEnumerable<GetAllRolePermissionsResponse>> GetAllRolePermissionsAsync(GetAllRolePermissionsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var rolePermissions = await _iRolePermission.GetAllAsync(request.Page);
            if (rolePermissions == null || rolePermissions.Count() == 0)
            {
                throw new KeyNotFoundException($"No role permissions found on page {request.Page}.");
            }
            return rolePermissions.Select(rp => new GetAllRolePermissionsResponse
            {
                Id = rp.Id,
                RoleId = rp.RoleId,
                PermissionId = rp.PermissionId
            });
        }
    }
}
