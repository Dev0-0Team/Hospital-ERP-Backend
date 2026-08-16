

using FluentValidation;
using Hospital_ERP_Backend.Domain.Interfaces.Permission;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetAllPermissionsOfUser
{
    public class GetAllPermissionsOfUserService : 
    IRequestHandler<GetAllPermissionsOfUserRequest, IEnumerable<GetAllPermissionsOfUserResponse>>
    {
        private readonly IValidator<GetAllPermissionsOfUserRequest> _validator;
        private readonly IPermissionQueryRepository _iPermission;

        public GetAllPermissionsOfUserService(IValidator<GetAllPermissionsOfUserRequest> validator, IPermissionQueryRepository iPermission)
        {
            _validator = validator;
            _iPermission = iPermission;
        }

        public async Task<IEnumerable<GetAllPermissionsOfUserResponse>> Handle(GetAllPermissionsOfUserRequest request, CancellationToken cancellationToken)
        {
            return await GetAllPermissionsOfUserAsync(request);
        }

        private async Task<IEnumerable<GetAllPermissionsOfUserResponse>> GetAllPermissionsOfUserAsync(GetAllPermissionsOfUserRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var permissions = await _iPermission.GetUserPermissionBitValuesAsync(request.UserId);
            if (permissions == null || permissions.Count() == 0)
            {
                throw new KeyNotFoundException($"No permissions found on page {request.UserId}.");
            }

            return permissions.Select(p => new GetAllPermissionsOfUserResponse
            {
                Group = p.Group,
                BitValue = p.BitValue
            });
        }
    }
}