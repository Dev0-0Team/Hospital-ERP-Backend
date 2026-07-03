using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionService : IRequestHandler<UpdatePermissionRequest, UpdatePermissionResponse>
    {
        private readonly IValidator<UpdatePermissionRequest> _validator;
        private readonly IBaseCommandRepository<Permission> _iPermission;
        private readonly IBaseQueryRepository<Permission> _iQueryPermission;

        public UpdatePermissionService(IValidator<UpdatePermissionRequest> validator, IBaseCommandRepository<Permission> iPermission, IBaseQueryRepository<Permission> iQueryPermission)
        {
            _validator = validator;
            _iPermission = iPermission;
            _iQueryPermission = iQueryPermission;
        }

        public async Task<UpdatePermissionResponse> Handle(UpdatePermissionRequest request, CancellationToken cancellationToken)
        {
            return await UpdatePermissionAsync(request);
        }

        private async Task<UpdatePermissionResponse> UpdatePermissionAsync(UpdatePermissionRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var permission = await _iQueryPermission.GetAsync(request.Id);
            if (permission == null)
            {
                throw new KeyNotFoundException($"Permission with Id {request.Id} not found.");
            }

            permission.Name = request.Name;
            permission.UpdatedAt = DateTime.Now;

            Permission? result = await _iPermission.UpdateAsync(permission);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update Permission.");
            }
            return new UpdatePermissionResponse 
            { 
                Id = result.Id,
                Name = result.Name
            };
        }
    }
}
