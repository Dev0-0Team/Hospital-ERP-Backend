

using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.UpdateNurse
{
    public class UpdateNurseValidator : AbstractValidator<UpdateNurseRequest>
    {
        public UpdateNurseValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be greater than 0.");

            RuleFor(x => x.PersonId)
                .GreaterThan(0).WithMessage("Person ID must be greater than 0.");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Department ID must be greater than 0.");
        }
    }
}
