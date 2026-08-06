using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetAllDoctors
{
    internal class GetAllDoctorsValidator : AbstractValidator<GetAllDoctorsRequest>
    {
        public GetAllDoctorsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page must be greater than 0.");
        }
    }
}