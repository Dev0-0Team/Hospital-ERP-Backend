using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.CreateRoomAssignment
{
    public record CreateRoomAssignmentRequest : IRequest<CreateRoomAssignmentResponse>
    {
        public int PatientId { get; set; }
        public int BedId { get; set; }
        public DateTime? AdmittedAt { get; set; }
        public DateTime? DischargedAt { get; set; }
    }
}