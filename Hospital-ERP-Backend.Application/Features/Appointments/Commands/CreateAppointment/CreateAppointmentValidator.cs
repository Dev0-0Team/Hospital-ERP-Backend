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
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(20).WithMessage("Status must not exceed 20 characters.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Appointment type is required.")
                .MaximumLength(20).WithMessage("Appointment type must not exceed 20 characters.");
        }
    }
}