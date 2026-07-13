using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Commands.CreateAppointment
{
    public record CreateAppointmentRequest : IRequest<CreateAppointmentResponse>
    {
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public int PriorityId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; } = "Pending";

        public string Type { get; set; } = null!;
    }
}