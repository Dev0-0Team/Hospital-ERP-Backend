

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetAllUserRoles
{
    public record GetAllUserRolesRequest : IRequest<IEnumerable<GetAllUserRolesResponse>>
    {
        public int Page{ get; set; }
    }
}
