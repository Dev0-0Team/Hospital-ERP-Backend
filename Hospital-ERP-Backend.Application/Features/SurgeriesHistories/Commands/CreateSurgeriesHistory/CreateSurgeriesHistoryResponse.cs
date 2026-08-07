using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.CreateSurgeriesHistory
{
    public class CreateSurgeriesHistoryResponse
    {
        public int Id {get; set;}
        public int PatientId { get; set; }
        public string SurgeryName { get; set; } = null!;
        public DateTime? SurgeryDate { get; set; }
    }
}