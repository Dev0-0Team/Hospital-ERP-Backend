using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Commands.CreatePermission
{
    public record CreatePermissionRequest : IRequest<CreatePermissionResponse>
    {
        public string Name { get; set; } = null!; 

    }
}
