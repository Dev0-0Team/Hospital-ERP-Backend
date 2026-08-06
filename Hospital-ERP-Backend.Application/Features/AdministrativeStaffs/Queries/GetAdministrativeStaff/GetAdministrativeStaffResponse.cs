using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Queries.GetAdministrativeStaff
{
    public record GetAdministrativeStaffResponse
    {
        public int Id {get; set;}
        public int PersonId {get;set;}
        public int DepartmentId {get; set;}
        public string JobTitle {get; set;} = null!;
    }
}