

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Users.Queries.GetAllUsers
{
    public record GetAllUsersRequest : IRequest<IEnumerable<GetAllUsersResponse>>
    {
        public int Page { get; set; }
    }
}
