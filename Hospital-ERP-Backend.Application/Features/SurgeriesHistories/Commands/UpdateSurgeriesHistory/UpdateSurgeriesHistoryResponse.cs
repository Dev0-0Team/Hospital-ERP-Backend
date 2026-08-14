

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.UpdateSurgeriesHistory
{
    public class UpdateSurgeriesHistoryResponse
    {
        public int Id {get; set;}
        public int PatientId { get; set; }
        public string SurgeryName { get; set; } = null!;
        public DateTime? SurgeryDate { get; set; }
    }
}