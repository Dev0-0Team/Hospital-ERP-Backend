

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetUserRoles
{
    public record GetUserRoleRequest : IRequest<GetUserRoleResponse>
    {
        public int Id { get; set; }
    }
}
