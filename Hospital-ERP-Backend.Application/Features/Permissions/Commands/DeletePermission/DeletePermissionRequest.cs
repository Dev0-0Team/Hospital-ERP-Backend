
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Commands.DeletePermission
{
    public record DeletePermissionRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
