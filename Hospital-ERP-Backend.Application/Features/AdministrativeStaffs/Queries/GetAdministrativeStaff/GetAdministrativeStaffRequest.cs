using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Queries.GetAdministrativeStaff
{
    public record GetAdministrativeStaffRequest : IRequest<GetAdministrativeStaffResponse>
    {
        public int Id {get; set;}
    }
}