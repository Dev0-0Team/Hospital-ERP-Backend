using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.CreateAppointmentQueue
{
    public class CreateAppointmentQueueValidator : AbstractValidator<CreateAppointmentQueueRequest>
    {
        public CreateAppointmentQueueValidator()
        {
            RuleFor(x => x.AppointmentId)
                .GreaterThan(0).WithMessage("Appointment ID must be greater than 0.");

            RuleFor(x => x.QueueNumber)
                .GreaterThan(0).WithMessage("Queue number must be greater than 0.");

            RuleFor(x => x.EstimatedTime)
                .GreaterThan(DateTime.Now).WithMessage("Estimated time must be in the future.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(20).WithMessage("Status must not exceed 20 characters.");
        }
    }
}