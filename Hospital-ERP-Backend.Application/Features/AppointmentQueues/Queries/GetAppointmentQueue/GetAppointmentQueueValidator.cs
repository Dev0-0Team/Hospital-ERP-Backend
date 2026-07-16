using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Queries.GetAppointmentQueue
{
    public class GetAppointmentQueueValidator : AbstractValidator<GetAppointmentQueueRequest>
    {
        public GetAppointmentQueueValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Appointment queue Id must be greater than 0.");
        }
    }
}