

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetRolePermissions
{
    internal class GetRolePermissionService : IRequestHandler<GetRolePermissionRequest, GetRolePermissionResponse>
    {
        private readonly IBaseQueryRepository<RolePermission> _iRolePermission;
        private readonly IValidator<GetRolePermissionRequest> _iValidator;

        public GetRolePermissionService(IBaseQueryRepository<RolePermission> iRolePermission, IValidator<GetRolePermissionRequest> iValidator)
        {
            _iRolePermission = iRolePermission;
            _iValidator = iValidator;
        }

        public async Task<GetRolePermissionResponse> Handle(GetRolePermissionRequest request, CancellationToken cancellationToken)
        {
            return await GetRolePermissionAsync(request);
        }

        private async Task<GetRolePermissionResponse> GetRolePermissionAsync(GetRolePermissionRequest request)
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
            return new GetRolePermissionResponse
            {
                Id = rolePermission.Id,
                RoleId = rolePermission.RoleId,
                PermissionId = rolePermission.PermissionId
            };
        }
    }
}
