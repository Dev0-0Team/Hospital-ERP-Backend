using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetAllPermissionsOfUser
{
    public record GetAllPermissionsOfUserRequest : IRequest<IEnumerable<GetAllPermissionsOfUserResponse>>
    {
        public int UserId {get;set;}
    }
}