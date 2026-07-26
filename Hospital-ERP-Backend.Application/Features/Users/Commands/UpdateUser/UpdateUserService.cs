using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Users.Commands.UpdateUser
{
    internal class UpdateUserService : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IValidator<UpdateUserRequest> _validator;
        private readonly IBaseCommandRepository<User> _iUser;
        private readonly IBaseQueryRepository<Person> _personRepository;
        private readonly IBaseQueryRepository<User> _iUserQuery;

        public UpdateUserService(IValidator<UpdateUserRequest> validator, IBaseQueryRepository<Person> personReopsitory,IBaseCommandRepository<User> iUser, IBaseQueryRepository<User> iUserQuery)
        {
            _validator = validator;
            _iUser = iUser;
            _iUserQuery = iUserQuery;
            _personRepository = personReopsitory;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            return await UpdateUserAsync(request);
        }

        private async Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Person? person = await _personRepository.GetAsync(request.PersonId);
            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.PersonId} not found.");
            }


            User? existingUser = await _iUserQuery.GetAsync(request.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with Id {request.Id} not found.");
            }
            existingUser.Email = request.Email;
            existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            existingUser.Status = request.Status.ToString();
            existingUser.PersonId = request.PersonId;
            existingUser.UpdatedAt = DateTime.UtcNow;

            User? result = await _iUser.UpdateAsync(existingUser);

            if (result == null)
            {
                throw new KeyNotFoundException($"User with Id {request.Id} not found.");
            }

            return new UpdateUserResponse
            {
                Id = result.Id,
                PersonId = result.PersonId,
                Status = result.Status,
                Email = result.Email
            };
        }
    }
}

