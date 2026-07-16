using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.CreateNurse
{
    public class CreateNurseValidator : AbstractValidator<CreateNurseRequest>
    {
        public CreateNurseValidator()
        {
            RuleFor(x => x.PersonId)
                .GreaterThan(0).WithMessage("Person ID must be greater than 0.");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Department ID must be greater than 0.");
        }
    }
}
