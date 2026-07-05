

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetUserRoles
{
    public class GetUserRoleService : IRequestHandler<GetUserRoleRequest, GetUserRoleResponse>
    {
        private readonly IBaseQueryRepository<UserRole> _iUserRole;
        private readonly IValidator<GetUserRoleRequest> _validator;

        public GetUserRoleService(IBaseQueryRepository<UserRole> iUserRole, IValidator<GetUserRoleRequest> validator)
        {
            _iUserRole = iUserRole;
            _validator = validator;
        }
        
        public async Task<GetUserRoleResponse> Handle(GetUserRoleRequest request, CancellationToken cancellationToken)
        {
            return await GetUserRoleAsync(request);
        }

        private async Task<GetUserRoleResponse> GetUserRoleAsync(GetUserRoleRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var userRole = await _iUserRole.GetAsync(request.Id);
            if (userRole == null)
            {
                throw new KeyNotFoundException($"User Role with Id {request.Id} not found.");
            }
            return new GetUserRoleResponse
            {
                Id = userRole.Id,
                UserId = userRole.UserId,
                RoleId = userRole.RoleId
            };
        }
    }
}
