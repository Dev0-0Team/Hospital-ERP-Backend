using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.UpdateDoctor
{
    internal class UpdateDoctorValidator : AbstractValidator<UpdateDoctorRequest>
    {
        public UpdateDoctorValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");

            RuleFor(x => x.PersonId)
                .GreaterThan(0)
                .WithMessage("Person Id must be greater than 0.");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0)
                .WithMessage("Department Id must be greater than 0.");

            RuleFor(x => x.SpecializationId)
                .GreaterThan(0)
                .WithMessage("Specialization Id must be greater than 0.");


            RuleFor(x => x.LicenseNumber)
                .NotEmpty().WithMessage("License Number is Required!")
                .MaximumLength(100).WithMessage("LicenseNumber must not exceed 100 characters.");
        }
    }
}