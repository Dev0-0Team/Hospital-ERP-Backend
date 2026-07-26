

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Commands.CreatePermission
{
    internal class CreatePermissionService : IRequestHandler<CreatePermissionRequest, CreatePermissionResponse>
    {
        private readonly IValidator<CreatePermissionRequest> _validator;
        private readonly IBaseCommandRepository<Permission> _iPermission;

        public CreatePermissionService(IValidator<CreatePermissionRequest> validator, IBaseCommandRepository<Permission> iPermission)
        {
            _validator = validator;
            _iPermission = iPermission;
        }

        public async Task<CreatePermissionResponse> Handle(CreatePermissionRequest request, CancellationToken cancellationToken)
        {
            return await CreatePermissionAsync(request);
        }

        private async Task<CreatePermissionResponse> CreatePermissionAsync(CreatePermissionRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var permission = new Permission
            {
                Name = request.Name,
                CreatedAt = DateTime.UtcNow
            };

            Permission? result = await _iPermission.CreateAsync(permission);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Permission.");
            }

            return new CreatePermissionResponse
            {
                Id = result.Id,
                Name = result.Name
            };
        }
    }
}
