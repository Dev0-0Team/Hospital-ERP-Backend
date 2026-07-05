

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetRolePermissions
{
    public record GetRolePermissionRequest : IRequest<GetRolePermissionResponse>
    {
        public int Id { get; set; }
    }
}
