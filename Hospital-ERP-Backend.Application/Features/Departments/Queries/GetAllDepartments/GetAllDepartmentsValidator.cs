using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.Departments.Queries.GetAllDepartments
{
    internal class GetAllDepartmentsValidator : AbstractValidator<GetAllDepartmentsRequest>
    {
        public GetAllDepartmentsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero.");
        }
    }
}
