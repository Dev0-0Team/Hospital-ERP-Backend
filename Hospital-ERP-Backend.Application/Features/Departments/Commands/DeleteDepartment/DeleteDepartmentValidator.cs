using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Departments.Commands.DeleteDepartment
{
    internal class DeleteDepartmentValidator : AbstractValidator<DeleteDepartmentRequest>
    {
        public DeleteDepartmentValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Department Id must be greater than 0.");
        }
    }
}
