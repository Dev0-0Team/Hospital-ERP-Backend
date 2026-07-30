

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

        public DeleteRoleService(IValidator<DeleteRoleRequest> validator, IBaseCommandRepository<Role> iRole)
        {
            _validator = validator;
            _iRole = iRole;
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

            bool role = await _iRole.IsExistAsync(request.Id);
            if (!role)
            {
                throw new KeyNotFoundException($"Role with Id {request.Id} not found.");
            }
            var isDeleted = await _iRole.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete role with Id {request.Id}.");
            }
            return isDeleted;
        }

    }
}
