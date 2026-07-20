using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Queries.GetAllDoctorSchedules
{
    public class GetAllDoctorSchedulesValidator
        : AbstractValidator<GetAllDoctorSchedulesRequest>
    {
        public GetAllDoctorSchedulesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Please enter number greater than 0");
        }
    }
}