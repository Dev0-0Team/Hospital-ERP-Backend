using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.DeleteDoctorSchedule
{
    public class DeleteDoctorScheduleValidator
        : AbstractValidator<DeleteDoctorScheduleRequest>
    {
        public DeleteDoctorScheduleValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Schedule Id must be greater than zero.");
        }
    }
}