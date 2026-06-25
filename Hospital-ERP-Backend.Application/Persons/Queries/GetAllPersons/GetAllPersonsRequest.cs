using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Persons.Queries.GetAllPersons
{
    public record GetAllPersonsRequest
    {
        public int page {  get; set; }
    }
}
