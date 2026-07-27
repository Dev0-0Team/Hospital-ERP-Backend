using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Queries.GetDoctorSchedule
{
    internal class GetDoctorScheduleValidator
        : AbstractValidator<GetDoctorScheduleRequest>
    {
        public GetDoctorScheduleValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Please enter id greater than 0");
        }
    }
}