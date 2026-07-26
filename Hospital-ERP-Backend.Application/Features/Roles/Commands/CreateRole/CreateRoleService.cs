using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Roles.Commands.CreateRole
{
    internal class CreateRoleService : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
    {
        private readonly IValidator<CreateRoleRequest> _validator;
        private readonly IBaseCommandRepository<Role> _iRole;

        public CreateRoleService(IValidator<CreateRoleRequest> validator, IBaseCommandRepository<Role> iRole)
        {
            _validator = validator;
            _iRole = iRole;
        }

        public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            return await CreateRoleAsync(request);
        }

        private async Task<CreateRoleResponse> CreateRoleAsync(CreateRoleRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Role role = new Role
            {
                Name = request.Name,
                UpdatedAt = DateTime.UtcNow
            };

            Role? result = await _iRole.CreateAsync(role);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create role.");
            }

            return new CreateRoleResponse()
            {
                Id = result.Id,
                Name = result.Name
            };
        }
}
}
