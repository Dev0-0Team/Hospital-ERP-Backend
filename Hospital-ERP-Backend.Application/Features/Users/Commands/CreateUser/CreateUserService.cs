using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Users.Commands.CreateUser
{
    internal class CreateUserService : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IValidator<CreateUserRequest> _validator;
        private readonly IBaseCommandRepository<Person> _personRepository;
        private readonly IBaseCommandRepository<User> _iUser;

        public CreateUserService(IValidator<CreateUserRequest> validator,IBaseCommandRepository<Person> personRepository ,IBaseCommandRepository<User> iUser)
        {
            _validator = validator;
            _iUser = iUser;
            _personRepository = personRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            return await CreateUserAsync(request);
        }

        private async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool person = await _personRepository.IsExistAsync(request.PersonId);
            if (!person)
            {
                throw new KeyNotFoundException($"Person with Id {request.PersonId} not found.");
            }

            User createUser = new User()
            {
                Email = request.Email,
                PersonId = request.PersonId,
                Status = request.Status.ToString(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow
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
