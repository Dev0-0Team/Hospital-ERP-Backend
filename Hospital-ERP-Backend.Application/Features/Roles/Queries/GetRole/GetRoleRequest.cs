

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Roles.Queries.GetRole
{
    public record GetRoleRequest : IRequest<GetRoleResponse>
    {
        public int Id { get; set; }
    }
}
