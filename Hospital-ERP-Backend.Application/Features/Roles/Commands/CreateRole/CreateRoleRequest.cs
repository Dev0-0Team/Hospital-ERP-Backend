

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Roles.Commands.CreateRole
{
    public record CreateRoleRequest : IRequest<CreateRoleResponse>
    {
        public string Name { get; set; } = null!;
    }
}
