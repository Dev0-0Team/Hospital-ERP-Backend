
namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Queries.GetSurgeriesHistory
{
    public class GetSurgeriesHistoryResponse
    {
        public int Id {get; set;}
        public int PatientId { get; set; }
        public string SurgeryName { get; set; } = null!;
        public DateTime? SurgeryDate { get; set; }
    }
}