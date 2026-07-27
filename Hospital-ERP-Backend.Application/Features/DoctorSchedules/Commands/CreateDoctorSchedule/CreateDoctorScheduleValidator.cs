using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.CreateDoctorSchedule
{
    internal class CreateDoctorScheduleValidator
        : AbstractValidator<CreateDoctorScheduleRequest>
    {
        public CreateDoctorScheduleValidator()
        {
            RuleFor(x => x.DoctorId)
                .GreaterThan(0)
                .WithMessage("Doctor Id must be greater than zero.");

            RuleFor(x => x.DayOfWeek)
                .IsInEnum()
                .WithMessage("Invalid day of week.");

            RuleFor(x => x)
                .NotEmpty().WithMessage("Start Time and End Time is Required.")
                .Must(x => x.StartTime < x.EndTime)
                .WithMessage("Start time must be before end time.");
        }
    }
}

