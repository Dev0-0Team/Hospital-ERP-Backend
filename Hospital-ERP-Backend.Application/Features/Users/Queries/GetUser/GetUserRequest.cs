
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Users.Queries.GetUser
{
    public record GetUserRequest : IRequest<GetUserResponse>
    {
        public int Id { get; set; }
    }
}
