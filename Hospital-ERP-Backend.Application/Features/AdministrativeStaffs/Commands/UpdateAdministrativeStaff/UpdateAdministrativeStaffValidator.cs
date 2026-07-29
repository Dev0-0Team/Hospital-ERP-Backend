
using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.UpdateAdministrativeStaff
{
    internal class UpdateAdministrativeStaffValidator : AbstractValidator<UpdateAdministrativeStaffRequest>
    {
        public UpdateAdministrativeStaffValidator()
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

                RuleFor(x => x.JobTitle)
                .NotEmpty().WithMessage("Job Title is Required")
                .MaximumLength(100)
                .WithMessage("Job Title must not exceed 100 characters");
        }
    }
}