

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetPermission
{
    public record GetPermissionRequest : IRequest<GetPermissionResponse>
    {
        public int Id { get; set; }
    }
}
