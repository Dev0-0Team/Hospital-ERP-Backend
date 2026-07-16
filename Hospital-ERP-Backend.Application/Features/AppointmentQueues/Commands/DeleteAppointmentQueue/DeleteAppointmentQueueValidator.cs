using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.DeleteAppointmentQueue
{
    public class DeleteAppointmentQueueValidator : AbstractValidator<DeleteAppointmentQueueRequest>
    {
        public DeleteAppointmentQueueValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}