using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Queries.GetAppointment
{
    internal class GetAppointmentValidator : AbstractValidator<GetAppointmentRequest>
    {
        public GetAppointmentValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}