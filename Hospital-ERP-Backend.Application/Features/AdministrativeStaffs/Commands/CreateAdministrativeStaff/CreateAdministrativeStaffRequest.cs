

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.CreateAdministrativeStaff
{
    public record CreateAdministrativeStaffRequest : IRequest<CreateAdministrativeStaffResponse>
    {
        public int PersonId {get; set;}
        public int DepartmentId {get; set;}
        public string JobTitle {get; set;} = null!;
    }
}