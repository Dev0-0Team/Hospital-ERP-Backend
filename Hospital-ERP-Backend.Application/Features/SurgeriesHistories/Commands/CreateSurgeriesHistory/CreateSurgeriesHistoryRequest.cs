

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.CreateSurgeriesHistory
{
    public class CreateSurgeriesHistoryRequest : IRequest<CreateSurgeriesHistoryResponse>
    {
        public int PatientId { get; set; }
        public string SurgeryName { get; set; } = null!;
        public DateTime? SurgeryDate { get; set; }
    }
}