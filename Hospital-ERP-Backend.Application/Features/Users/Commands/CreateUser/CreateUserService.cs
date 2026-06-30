using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Persons.Commands.CreatePerson;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserService
    {
        private readonly IValidator<CreateUserRequest> _validator;
        private readonly IBaseCommandRepository<User> _iUser;
        private readonly IBaseQueryRepository<User> _iUserQuery;

        public CreateUserService(IValidator<CreateUserRequest> validator, IBaseCommandRepository<User> iUser, IBaseQueryRepository<User> iUserQuery)
        {
            _validator = validator;
            _iUser = iUser;
            _iUserQuery = iUserQuery;
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            User createUser = new User()
            {
                Email = request.Email,
                PersonId = request.PersonId,
                Status = request.Status,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            User? result = await _iUser.CreateAsync(createUser);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create User.");
            }

            return new CreateUserResponse
            {
                Id = result.Id,
                PersonId = result.PersonId,
                Status = result.Status,
                Email = result.Email
            };
        }
    }
}
