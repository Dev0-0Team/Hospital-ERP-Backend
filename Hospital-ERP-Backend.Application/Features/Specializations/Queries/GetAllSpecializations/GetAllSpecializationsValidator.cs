using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Specializations.Queries.GetAllSpecializations
{
    internal class GetAllSpecializationsValidator : AbstractValidator<GetAllSpecializationsRequest>
    {
        public GetAllSpecializationsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}
