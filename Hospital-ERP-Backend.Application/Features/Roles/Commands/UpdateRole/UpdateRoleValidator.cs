using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Roles.Commands.UpdateRole
{
    internal class UpdateRoleValidator : AbstractValidator<UpdateRoleRequest>
    {
        public UpdateRoleValidator() 
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
        }
    }
}
