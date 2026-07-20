using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.UpdateRoomAssignment
{
    public record UpdateRoomAssignmentRequest : IRequest<UpdateRoomAssignmentResponse>
    {
        public int Id { get; init; }
        public int PatientId { get; init; }
        public int BedId { get; init; }
        public DateTime AdmittedAt { get; init; }
        public DateTime? DischargedAt { get; init; }
    }
}