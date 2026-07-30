

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Command.CreateRolePermission
{
    internal class CreateRolePermissionService : IRequestHandler<CreateRolePermissionRequest, CreateRolePermissionResponse>
    {
        private readonly IBaseCommandRepository<RolePermission> _iRolePermission;
        private readonly IBaseCommandRepository<Role> _iRoleCommand;
        private readonly IBaseCommandRepository<Permission> _iPermissionCommand;
        private readonly IValidator<CreateRolePermissionRequest> _iValidator;

        public CreateRolePermissionService(
            IBaseCommandRepository<RolePermission> iRolePermission,
            IBaseCommandRepository<Role> iRoleQuery,
            IBaseCommandRepository<Permission> iPermissionQuery,
            IValidator<CreateRolePermissionRequest> iValidator)
        {
            _iRolePermission = iRolePermission;
            _iRoleCommand = iRoleQuery;
            _iPermissionCommand = iPermissionQuery;
            _iValidator = iValidator;
        }

        public async Task<CreateRolePermissionResponse> Handle(CreateRolePermissionRequest request, CancellationToken cancellationToken)
        {
            return await CreateRolePermissionAsync(request);
        }

        private async Task<CreateRolePermissionResponse> CreateRolePermissionAsync(CreateRolePermissionRequest request)
        {
            var validationResult = await _iValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool isRoleFound = await _iRoleCommand.IsExistAsync(request.RoleId);
            if (!isRoleFound)
            {
                throw new KeyNotFoundException($"Role with Id {request.RoleId} not found.");
            }

            bool isPermissionFound = await _iPermissionCommand.IsExistAsync(request.PermissionId);
            if (!isPermissionFound)
            {
                throw new KeyNotFoundException($"Permission with Id {request.PermissionId} not found.");
            }

            RolePermission createRolePermission = new RolePermission()
            {
                RoleId = request.RoleId,
                PermissionId = request.PermissionId,
                UpdatedAt = DateTime.UtcNow
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
