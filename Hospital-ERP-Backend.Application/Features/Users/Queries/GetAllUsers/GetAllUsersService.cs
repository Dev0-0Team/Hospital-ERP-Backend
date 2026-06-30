using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Persons.Queries.GetAllPersons;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.Users.Queries.GetAllUsers
{
    internal class GetAllUsersService
    {
        private readonly IValidator<GetAllUsersRequest> _validator;
        private readonly IBaseQueryRepository<User> _iUser;

        public GetAllUsersService(IValidator<GetAllUsersRequest> getAllUsersRequest, IBaseQueryRepository<User> iUser)
        {
            _validator = getAllUsersRequest;
            _iUser = iUser;
        }

        public async Task<IEnumerable<GetAllUsersResponse>> GetAllUsersAsync(GetAllUsersRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var users = await _iUser.GetAllAsync(request.Page);
            if (users == null || users.Count() == 0)
            {
                throw new KeyNotFoundException($"No users found on page {request.Page}.");
            }

            return users.Select(p => new GetAllUsersResponse
            {
                Id = p.Id,
                PersonId = p.PersonId,
                Email = p.Email,
                Status = p.Status,
            });
        }
    }
}
