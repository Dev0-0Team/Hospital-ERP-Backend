

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Command.DeleteRolePermission
{
    internal class DeleteRolePermissionService : IRequestHandler<DeleteRolePermissionRequest, bool>
    {
        private readonly IBaseCommandRepository<RolePermission> _iRolePermission;
        private readonly IValidator<DeleteRolePermissionRequest> _iValidator;

        public DeleteRolePermissionService(IBaseCommandRepository<RolePermission> iRolePermission, IValidator<DeleteRolePermissionRequest> iValidator)
        {
            _iRolePermission = iRolePermission;
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
            bool rolePermission = await _iRolePermission.IsExistAsync(request.Id);
            if (!rolePermission)
            {
                throw new KeyNotFoundException($"Role Permission with Id {request.Id} not found.");
            }
            bool isDeleted = await _iRolePermission.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete role permission with Id {request.Id}.");
            }
            return isDeleted;
        }
    }
}
