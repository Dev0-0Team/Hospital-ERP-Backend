

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Roles.Queries.GetAllRoles
{
    internal class GetAllRolesService : IRequestHandler<GetAllRolesRequest, IEnumerable<GetAllRolesResponse>>
    {
        private readonly IValidator<GetAllRolesRequest> _validator;
        private readonly IBaseQueryRepository<Role> _iRole;

        public GetAllRolesService(IValidator<GetAllRolesRequest> validator, IBaseQueryRepository<Role> iRole)
        {
            _validator = validator;
            _iRole = iRole;
        }

        public async Task<IEnumerable<GetAllRolesResponse>> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
        {
            return await GetAllRolesAsync(request);
        }

        private async Task<IEnumerable<GetAllRolesResponse>> GetAllRolesAsync(GetAllRolesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var roles = await _iRole.GetAllAsync(request.Page);
            if (roles == null || roles.Count() == 0)
            {
                throw new KeyNotFoundException($"No roles found on page {request.Page}.");
            }

            return roles.Select(r => new GetAllRolesResponse
            {
                Id = r.Id,
                Name = r.Name
            });
        }
    }
}
