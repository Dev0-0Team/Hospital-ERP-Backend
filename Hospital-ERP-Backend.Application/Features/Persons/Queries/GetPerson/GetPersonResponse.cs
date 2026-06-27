using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.Persons.Queries.GetPerson
{
    public record GetPersonResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Gender { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Address { get; set; }
    }
}
