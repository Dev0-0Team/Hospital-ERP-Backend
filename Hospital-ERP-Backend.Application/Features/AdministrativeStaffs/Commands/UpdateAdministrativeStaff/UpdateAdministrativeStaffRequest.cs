using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.UpdateAdministrativeStaff
{
    public record UpdateAdministrativeStaffRequest : IRequest<UpdateAdministrativeStaffResponse>
    {
        public int Id {get; set;}
        public int PersonId {get; set;}
        public int DepartmentId {get; set;}
        public string JobTitle {get; set;} = null!;
    }
}