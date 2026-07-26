using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.CreateUserRole
{
    internal class CreateUserRoleService : IRequestHandler<CreateUserRoleRequest, CreateUserRoleResponse>
    {
        private readonly IBaseCommandRepository<UserRole> _iUserRole;
        private readonly IBaseQueryRepository<User> _iUserQuery;
        private readonly IBaseQueryRepository<Role> _iRoleQuery;
        private readonly IValidator<CreateUserRoleRequest> _validator;

        public CreateUserRoleService(
            IBaseCommandRepository<UserRole> iUserRole,
            IBaseQueryRepository<User> iUserQuery,
            IBaseQueryRepository<Role> iRoleQuery,
            IValidator<CreateUserRoleRequest> validator)
        {
            _iUserRole = iUserRole;
            _iUserQuery = iUserQuery;
            _iRoleQuery = iRoleQuery;
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

            User? isFound = await _iUserQuery.GetAsync(request.UserId);
            if (isFound == null)
            {
                throw new KeyNotFoundException($"User with Id {request.UserId} not found.");
            }

            Role? isRoleFound = await _iRoleQuery.GetAsync(request.RoleId);
            if (isRoleFound == null)
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

