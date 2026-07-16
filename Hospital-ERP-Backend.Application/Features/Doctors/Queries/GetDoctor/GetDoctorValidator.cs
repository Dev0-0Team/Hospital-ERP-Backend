using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetDoctor
{
    public class GetDoctorValidator : AbstractValidator<GetDoctorRequest>
    {
        public GetDoctorValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}