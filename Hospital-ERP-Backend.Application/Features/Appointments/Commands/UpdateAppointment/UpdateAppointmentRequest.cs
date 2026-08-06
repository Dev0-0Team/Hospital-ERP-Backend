using Hospital_ERP_Backend.Domain.Enums.Appointment;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Commands.UpdateAppointment
{
    public record UpdateAppointmentRequest : IRequest<UpdateAppointmentResponse>
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public int PriorityId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

        public AppointmentType Type { get; set; } 
    }
}