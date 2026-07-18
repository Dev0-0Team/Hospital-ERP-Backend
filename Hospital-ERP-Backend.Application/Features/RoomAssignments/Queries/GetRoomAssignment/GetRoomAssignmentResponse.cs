namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Queries.GetRoomAssignment
{
    public record GetRoomAssignmentResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int BedId { get; set; }
        public DateTime AdmittedAt { get; set; }
        public DateTime? DischargedAt { get; set; }
    }
}