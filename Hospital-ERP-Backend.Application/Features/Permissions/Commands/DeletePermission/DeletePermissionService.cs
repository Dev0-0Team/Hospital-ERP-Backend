using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Commands.DeletePermission
{
    internal class DeletePermissionService : IRequestHandler<DeletePermissionRequest, bool>
    {
        private readonly IBaseCommandRepository<Permission> _iPermission;
        private readonly IValidator<DeletePermissionRequest> _validator;

        public DeletePermissionService(IBaseCommandRepository<Permission> iPermission, IValidator<DeletePermissionRequest> validator)
        {
            _iPermission = iPermission;
            _validator = validator;
        }
        
        public async Task<bool> Handle(DeletePermissionRequest request, CancellationToken cancellationToken)
        {
            return await DeletePermissionAsync(request);
        }

        private async Task<bool> DeletePermissionAsync(DeletePermissionRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            bool permission = await _iPermission.IsExistAsync(request.Id);
            if (!permission)
            {
                throw new KeyNotFoundException($"Permission with Id {request.Id} not found.");
            }
            var isDeleted = await _iPermission.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete permission with Id {request.Id}.");
            }
            return isDeleted;
        }
    }
}
