

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetAllPermissions
{
    public record GetAllPermissionsRequest : IRequest<IEnumerable<GetAllPermissionsResponse>>
    {
        public int Page { get; set; }
    }
}
