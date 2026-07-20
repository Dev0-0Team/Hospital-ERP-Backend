using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.CreateDoctorSchedule
{
    public class CreateDoctorScheduleValidator
        : AbstractValidator<CreateDoctorScheduleRequest>
    {
        private readonly string[] _days =
        {
            "Saturday",
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday"
        };

        public CreateDoctorScheduleValidator()
        {
            RuleFor(x => x.DoctorId)
                .GreaterThan(0);

            RuleFor(x => x.DayOfWeek)
                .NotEmpty()
                .Must(day => _days.Contains(day))
                .WithMessage("Invalid day of week.");

            RuleFor(x => x)
                .Must(x => x.StartTime < x.EndTime)
                .WithMessage("Start time must be before end time.");
        }
    }
}

