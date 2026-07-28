
namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.CreateAdministrativeStaff
{
    public record CreateAdministrativeStaffResponse
    {
        public int Id {get; set;}
        public int PersonId {get; set;}
        public int DepartmentId {get; set;}
        public string JobTitle {get; set;} = null!;
    }
}