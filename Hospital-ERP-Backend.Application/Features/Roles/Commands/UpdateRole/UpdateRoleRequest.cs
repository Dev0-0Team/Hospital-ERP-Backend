

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Roles.Commands.UpdateRole
{
    public record UpdateRoleRequest : IRequest<UpdateRoleResponse>
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
    }
}
