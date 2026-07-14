using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Departments.Queries.GetDepartment
{
    public class GetDepartmentValidator : AbstractValidator<GetDepartmentRequest>
    {
        public GetDepartmentValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Department Id must be greater than 0.");
        }
    }
}
