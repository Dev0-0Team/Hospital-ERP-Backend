using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetDoctor
{
    internal class GetDoctorValidator : AbstractValidator<GetDoctorRequest>
    {
        public GetDoctorValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}