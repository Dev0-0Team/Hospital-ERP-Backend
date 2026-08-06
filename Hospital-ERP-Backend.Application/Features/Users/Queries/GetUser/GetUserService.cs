

using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Users.Queries.GetUser
{
    internal class GetUserService : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IValidator<GetUserRequest> _validator;
        private readonly IBaseQueryRepository<User> _iUser;

        public GetUserService(IValidator<GetUserRequest> validator, IBaseQueryRepository<User> iUser)
        {
            _validator = validator;
            _iUser = iUser;
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            return await GetUserAsync(request);
        }

        private async Task<GetUserResponse> GetUserAsync(GetUserRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var user = await _iUser.GetAsync(request.Id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id {request.Id} not found.");
            }

            return new GetUserResponse
            {
                Id = user.Id,
                PersonId = user.PersonId,
                Email = user.Email,
                Status = user.Status
            };
        }
    }
}
