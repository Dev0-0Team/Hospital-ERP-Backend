using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Queries.GetAllNurses
{
    public record GetAllNursesResponse
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int DepartmentId { get; set; }
    }
}
