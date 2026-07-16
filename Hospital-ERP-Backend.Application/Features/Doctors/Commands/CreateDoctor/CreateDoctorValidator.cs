using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorValidator : AbstractValidator<CreateDoctorRequest>
    {
        public CreateDoctorValidator()
        {
            RuleFor(x => x.PersonId)
                .GreaterThan(0);

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0);

            RuleFor(x => x.SpecializationId)
                .GreaterThan(0);

            RuleFor(x => x.LicenseNumber)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}