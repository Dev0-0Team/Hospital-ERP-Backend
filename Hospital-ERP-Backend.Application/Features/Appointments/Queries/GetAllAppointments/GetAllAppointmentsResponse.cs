namespace Hospital_ERP_Backend.Application.Features.Appointments.Queries.GetAllAppointments
{
    public record GetAllAppointmentsResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public int PriorityId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; } = null!;

        public string Type { get; set; } = null!;
    }
}