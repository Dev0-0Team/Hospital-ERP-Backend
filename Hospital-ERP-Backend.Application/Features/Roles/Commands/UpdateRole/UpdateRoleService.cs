
using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleService
    {
        private readonly IValidator<UpdateRoleRequest> _validator;
        private readonly IBaseCommandRepository<Role> _iRole;
        private readonly IBaseQueryRepository<Role> _iQueryRole;

        public UpdateRoleService(IValidator<UpdateRoleRequest> validator, IBaseCommandRepository<Role> iRole, IBaseQueryRepository<Role> iQueryRole)
        {
            _validator = validator;
            _iRole = iRole;
            _iQueryRole = iQueryRole;
        }

        public async Task<UpdateRoleResponse> UpdateRoleAsync(UpdateRoleRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            
            Role? existingRole = await _iQueryRole.GetAsync(request.Id);
            if (existingRole == null)
            {
                throw new KeyNotFoundException($"Role with Id {request.Id} not found.");
            }

            existingRole.Name = request.Name;
            Role? result = await _iRole.UpdateAsync(existingRole);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update role.");
            }

            return new UpdateRoleResponse
            {
                Id = result.Id,
                Name = result.Name
            };
        }
    }
}
