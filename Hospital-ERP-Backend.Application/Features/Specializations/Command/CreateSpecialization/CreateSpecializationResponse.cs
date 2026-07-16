using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.Specializations.Command.CreateSpecialization
{
    public record CreateSpecializationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
