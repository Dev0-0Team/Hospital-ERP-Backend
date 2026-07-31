using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Queries.GetAllAppointmentQueues
{
    internal class GetAllAppointmentQueuesValidator : AbstractValidator<GetAllAppointmentQueuesRequest>
    {
        public GetAllAppointmentQueuesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}