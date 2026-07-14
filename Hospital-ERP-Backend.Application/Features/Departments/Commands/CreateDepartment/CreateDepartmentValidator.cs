using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentRequest>
    {
        public CreateDepartmentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        }
    }
}
