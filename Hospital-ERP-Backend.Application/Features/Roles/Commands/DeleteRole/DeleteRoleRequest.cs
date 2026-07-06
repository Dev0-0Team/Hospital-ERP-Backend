

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Roles.Commands.DeleteRole
{
    public record DeleteRoleRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
