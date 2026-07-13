using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.CreatePrescription
{
    public record CreatePrescriptionRequest : IRequest<CreatePrescriptionResponse>
    {
        public int PatientId { get; set; }

        public int DoctorId { get; set; }
    }
}