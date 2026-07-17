using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.Patients.Command.UpdatePatient
{
    public record UpdatePatientCommand
    {
        public int PersonId { get; set; }

        public string? BloodType { get; set; }
    }
}
