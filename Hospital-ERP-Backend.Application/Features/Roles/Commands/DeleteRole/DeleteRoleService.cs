

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Roles.Commands.DeleteRole
{
    internal class DeleteRoleService : IRequestHandler<DeleteRoleRequest, bool>
    {
        private readonly IValidator<DeleteRoleRequest> _validator;
        private readonly IBaseCommandRepository<Role> _iRole;
        private readonly IBaseQueryRepository<Role> _iRoleQuery;

        public DeleteRoleService(IValidator<DeleteRoleRequest> validator, IBaseCommandRepository<Role> iRole, IBaseQueryRepository<Role> iRoleQuery)
        {
            _validator = validator;
            _iRole = iRole;
            _iRoleQuery = iRoleQuery;
        }

        public async Task<bool> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
        {
            return await DeleteRoleAsync(request);
        }

        private async Task<bool> DeleteRoleAsync(DeleteRoleRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var role = await _iRoleQuery.GetAsync(request.Id);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with Id {request.Id} not found.");
            }
            var isDeleted = await _iRole.DeleteAsync(role.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete role with Id {request.Id}.");
            }
            return isDeleted;
        }

    }
}
