

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.Roles.Queries.GetRole
{
    public class GetRoleService
    {
        private readonly IValidator<GetRoleRequest> _validator;
        private readonly IBaseQueryRepository<Role> _iRole;
        public GetRoleService(IValidator<GetRoleRequest> validator, IBaseQueryRepository<Role> iRole)
        {
            _validator = validator;
            _iRole = iRole;
        }


        public async Task<GetRoleResponse> GetRoleAsync(GetRoleRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var role = await _iRole.GetAsync(request.Id);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with Id {request.Id} not found.");
            }
            return new GetRoleResponse
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}

