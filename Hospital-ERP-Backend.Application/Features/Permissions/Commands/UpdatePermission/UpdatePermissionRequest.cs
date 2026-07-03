

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Commands.UpdatePermission
{
    public record UpdatePermissionRequest : IRequest<UpdatePermissionResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
