using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetAllUserRoles
{
    public class GetAllUserRolesService : IRequestHandler<GetAllUserRolesRequest, IEnumerable<GetAllUserRolesResponse>>
    {
        private readonly IValidator<GetAllUserRolesRequest> _validator;
        private readonly IBaseQueryRepository<UserRole> _iUserRole;

        public GetAllUserRolesService(IValidator<GetAllUserRolesRequest> validator, IBaseQueryRepository<UserRole> iUserRole)
        {
            _validator = validator;
            _iUserRole = iUserRole;
        }

        public async Task<IEnumerable<GetAllUserRolesResponse>> Handle(GetAllUserRolesRequest request, CancellationToken cancellationToken)
        {
            return await GetAllUserRolesAsync(request);
        }

        private async Task<IEnumerable<GetAllUserRolesResponse>> GetAllUserRolesAsync(GetAllUserRolesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var userRoles = await _iUserRole.GetAllAsync(request.Page);
            if (userRoles == null || userRoles.Count() == 0)
            {
                throw new KeyNotFoundException($"No user roles found on page {request.Page}.");
            }

            return userRoles.Select(ur => new GetAllUserRolesResponse
            {
                Id = ur.Id,
                UserId = ur.UserId,
                RoleId = ur.RoleId
            });
        }
    }
}
