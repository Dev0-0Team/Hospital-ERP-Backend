using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Commands.CreateAppointment
{
    internal class CreateAppointmentValidator : AbstractValidator<CreateAppointmentRequest>
    {
        public CreateAppointmentValidator()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Patient ID must be greater than 0.");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("Doctor ID must be greater than 0.");

            RuleFor(x => x.PriorityId)
                .GreaterThan(0).WithMessage("Priority ID must be greater than 0.");

            RuleFor(x => x.AppointmentDate)
                .GreaterThan(DateTime.Now).WithMessage("Appointment date must be in the future.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("invalid Status");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("invalid Type");
        }
    }   
}