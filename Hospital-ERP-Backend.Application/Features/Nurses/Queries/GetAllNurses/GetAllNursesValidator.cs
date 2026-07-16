

using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Queries.GetAllNurses
{
    public class GetAllNursesValidator : AbstractValidator<GetAllNursesRequest>
    {
        public GetAllNursesValidator()
        {
            RuleFor(x => x.Page)
               .GreaterThan(0).WithMessage("Page must be greater than 0.");
        }
    }
}
