using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetPermission
{
    public class GetPermissionService : IRequestHandler<GetPermissionRequest, GetPermissionResponse>
    {
        private readonly IBaseQueryRepository<Permission> _iPermission;
        private readonly IValidator<GetPermissionRequest> _validator;

        public GetPermissionService(IBaseQueryRepository<Permission> iPermission, IValidator<GetPermissionRequest> validator)
        {
            _iPermission = iPermission;
            _validator = validator;
        }

        public async Task<GetPermissionResponse> Handle(GetPermissionRequest request, CancellationToken cancellationToken)
        {
            return await GetPermissionAsync(request);
        }

        private async Task<GetPermissionResponse> GetPermissionAsync(GetPermissionRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Permission? permission = await _iPermission.GetAsync(request.Id);
            if (permission == null)
            {
                throw new KeyNotFoundException($"Permission with Id {request.Id} not found.");
            }

            return new GetPermissionResponse
            {
                Id = permission.Id,
                Name = permission.Name
            };
        }
    }
}
