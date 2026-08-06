

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Queries.GetAllAdministrativeStaffs
{
    public record GetAllAdministrativeStaffsResponse
    {
        public int Id {get; set;}
        public int PersonId {get; set;}
        public int DepartmentId {get; set;}
        public string jobTitle {get; set;} = null!;
    }
}