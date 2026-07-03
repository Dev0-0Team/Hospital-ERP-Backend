

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Command.DeleteRolePermission
{
    public class DeleteRolePermissionService : IRequestHandler<DeleteRolePermissionRequest, bool>
    {
        private readonly IBaseCommandRepository<RolePermission> _iRolePermission;
        private readonly IBaseQueryRepository<RolePermission> _iRolePermissionQuery;
        private readonly IValidator<DeleteRolePermissionRequest> _iValidator;

        public DeleteRolePermissionService(IBaseCommandRepository<RolePermission> iRolePermission, IBaseQueryRepository<RolePermission> iRolePermissionQuery, IValidator<DeleteRolePermissionRequest> iValidator)
        {
            _iRolePermission = iRolePermission;
            _iRolePermissionQuery = iRolePermissionQuery;
            _iValidator = iValidator;
        }

        public async Task<bool> Handle(DeleteRolePermissionRequest request, CancellationToken cancellationToken)
        {
            return await DeleteRolePermissionAsync(request);
        }

        private async Task<bool> DeleteRolePermissionAsync(DeleteRolePermissionRequest request)
        {
            var validationResult = await _iValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            RolePermission? rolePermission = await _iRolePermissionQuery.GetAsync(request.Id);
            if (rolePermission == null)
            {
                throw new KeyNotFoundException($"Role Permission with Id {request.Id} not found.");
            }
            bool isDeleted = await _iRolePermission.DeleteAsync(rolePermission.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete role permission with Id {request.Id}.");
            }
            return isDeleted;
        }
    }
}
