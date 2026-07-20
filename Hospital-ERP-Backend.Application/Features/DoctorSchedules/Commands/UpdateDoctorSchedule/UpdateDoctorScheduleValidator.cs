using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.UpdateDoctorSchedule
{
    public class UpdateDoctorScheduleValidator
        : AbstractValidator<UpdateDoctorScheduleRequest>
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

        public UpdateDoctorScheduleValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Schedule Id must be greater than zero.");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0)
                .WithMessage("Doctor Id must be greater than zero.");

            RuleFor(x => x.DayOfWeek)
                .NotEmpty()
                .WithMessage("Day Of Week is required.")
                .Must(day => _days.Contains(day))
                .WithMessage("Day Of Week must be a valid day.");

            RuleFor(x => x)
                .Must(x => x.StartTime < x.EndTime)
                .WithMessage("Start Time must be less than End Time.");
        }
    }
}