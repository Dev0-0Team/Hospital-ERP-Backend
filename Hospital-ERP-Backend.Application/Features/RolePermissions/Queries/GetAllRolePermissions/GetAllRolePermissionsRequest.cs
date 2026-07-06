

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetAllRolePermissions
{
    public record GetAllRolePermissionsRequest : IRequest<IEnumerable<GetAllRolePermissionsResponse>>
    {
        public int Page { get; set; }
    }
}
