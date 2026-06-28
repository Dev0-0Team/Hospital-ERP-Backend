

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetAllPermissions
{
    public class GetAllPermissionsService
    {
        private readonly IValidator<GetAllPermissionsRequest> _validator;
        private readonly IBaseQueryRepository<Permission> _iPermission;

        public GetAllPermissionsService(IValidator<GetAllPermissionsRequest> validator, IBaseQueryRepository<Permission> iPermission)
        {
            _validator = validator;
            _iPermission = iPermission;
        }

        public async Task<IEnumerable<GetAllPermissionsResponse>> GetAllPermissionsAsync(GetAllPermissionsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var permissions = await _iPermission.GetAllAsync(request.Page);
            if (permissions == null || permissions.Count() == 0)
            {
                throw new KeyNotFoundException($"No permissions found on page {request.Page}.");
            }

            return permissions.Select(p => new GetAllPermissionsResponse
            {
                Id = p.Id,
                Name = p.Name
            });
        }
    }
}
