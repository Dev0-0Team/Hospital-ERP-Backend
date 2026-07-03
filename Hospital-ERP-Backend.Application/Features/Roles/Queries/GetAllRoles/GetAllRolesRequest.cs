

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Roles.Queries.GetAllRoles
{
    public record GetAllRolesRequest : IRequest<IEnumerable<GetAllRolesResponse>>
    {
        public int Page {  get; set; }
    }
}
