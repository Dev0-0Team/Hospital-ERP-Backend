using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.CreateUserRole
{
    internal class CreateUserRoleService : IRequestHandler<CreateUserRoleRequest, CreateUserRoleResponse>
    {
        private readonly IBaseCommandRepository<UserRole> _iUserRole;
        private readonly IBaseCommandRepository<User> _iUserCommand;
        private readonly IBaseCommandRepository<Role> _iRoleCommand;
        private readonly IValidator<CreateUserRoleRequest> _validator;

        public CreateUserRoleService(
            IBaseCommandRepository<UserRole> iUserRole,
            IBaseCommandRepository<User> iUserQuery,
            IBaseCommandRepository<Role> iRoleQuery,
            IValidator<CreateUserRoleRequest> validator)
        {
            _iUserRole = iUserRole;
            _iUserCommand = iUserQuery;
            _iRoleCommand = iRoleQuery;
            _validator = validator;
        }

        public async Task<CreateUserRoleResponse> Handle(CreateUserRoleRequest request, CancellationToken cancellationToken)
        {
            return await CreateUserRoleAsync(request);
        }

        private async Task<CreateUserRoleResponse> CreateUserRoleAsync(CreateUserRoleRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            UserRole createUserRole = new UserRole()
            {
                UserId = request.UserId,
                RoleId = request.RoleId,
                CreatedAt = DateTime.UtcNow
            };

            bool isFound = await _iUserCommand.IsExistAsync(request.UserId);
            if (!isFound)
            {
                throw new KeyNotFoundException($"User with Id {request.UserId} not found.");
            }

            bool isRoleFound = await _iRoleCommand.IsExistAsync(request.RoleId);
            if (!isRoleFound)
            {
                throw new KeyNotFoundException($"Role with Id {request.RoleId} not found.");
            }

            UserRole? result = await _iUserRole.CreateAsync(createUserRole);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create User Role.");
            }

            return new CreateUserRoleResponse
            {
                Id = result.Id,
                UserId = result.UserId,
                RoleId = result.RoleId
            };
        }
    }
}

