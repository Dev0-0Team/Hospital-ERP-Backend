using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Commands.DeleteAppointment
{
    internal class DeleteAppointmentValidator : AbstractValidator<DeleteAppointmentRequest>
    {
        public DeleteAppointmentValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}